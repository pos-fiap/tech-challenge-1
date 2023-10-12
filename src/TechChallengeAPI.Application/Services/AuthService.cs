using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;
using TechChallenge.Application.Models;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public string GenerateJwtToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value!));

            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            string jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public RefreshTokenModel GenerateRefreshToken()
        {
            byte[] randomNumber = new byte[64];
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            RefreshTokenModel refreshToken = new()
            {
                RefreshToken = Convert.ToBase64String(randomNumber),
                ExpirationDate = DateTime.UtcNow.AddSeconds(10)
            };
            return refreshToken;
        }

        public async Task<BaseOutput<TokenDto>> RefreshExpiratedTokenAsync(TokenDto tokenDto)
        {
            BaseOutput<TokenDto> response = new BaseOutput<TokenDto>();

            if (tokenDto == null)
            {
                response.AddError("Invalid client request");
                return response;
            }

            string accessToken = tokenDto!.Token;
            string refreshToken = tokenDto.RefreshToken;

            ClaimsPrincipal principal = GetPrincipalFromExpiredToken(accessToken);
            string username = principal.Identity?.Name ?? string.Empty;
            User user = await _userService.GetUser(username);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryDate >= DateTime.Now)
            {
                response.AddError("Invalid client request");
                return response;
            }

            string newAccessToken = GenerateJwtToken(user);
            RefreshTokenModel newRefreshToken = GenerateRefreshToken();

            await _userService.UpdateUserRefreshToken(user, newRefreshToken);

            TokenDto token = new TokenDto
            {
                Token = newAccessToken,
                RefreshToken = newRefreshToken.RefreshToken
            };

            response.Response = token;
            return response;
        }

        public BaseOutput<string> ValidateLogin(User user, LoginDto loginDto)
        {
            BaseOutput<string> response = new()
            {
                IsSuccessful = true
            };

            if (user.Username != loginDto.Username || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                response.IsSuccessful = false;
                response.AddError("Incorrect User or Password");
                return response;
            }

            return response;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string expiredToken)
        {
            TokenValidationParameters tokenValidationParameters = new()
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value!)),
                ValidateLifetime = false
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            ClaimsPrincipal principal = tokenHandler.ValidateToken(expiredToken, tokenValidationParameters, out SecurityToken securityToken);

            JwtSecurityToken? jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512Signature, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
    }
}
