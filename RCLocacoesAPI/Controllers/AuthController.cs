using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RCLocacoes.Application.BaseResponse;
using RCLocacoes.Application.DTOs;
using RCLocacoes.Application.Interfaces;
using RCLocacoes.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace RCLocacoes.Api.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(BaseOutput<int>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<int>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDto userDto, [FromServices] IValidator<UserDto> validator)
        {
            try
            {
                ValidationResult validationResult = validator.Validate(userDto);

                if (!validationResult.IsValid)
                {
                    return ValidatorErrorResponse(validationResult.Errors);
                }

                var userExists = await _userService.VerifyUser(userDto);

                if (userExists)
                {
                    return BadRequestResponse("Erro ao cadastrar este e-mail!");
                }

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

                userDto.Password = passwordHash;

                BaseOutput<int> id = await _userService.RegisterUser(userDto);

                return Ok(id);
            }
            catch (Exception ex)
            {

                return InternalErrorResponse(ex);
            }

        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Login([FromBody] UserDto userDto, [FromServices] IValidator<UserDto> validator)
        {
            try
            {
                ValidationResult validationResult = validator.Validate(userDto);

                if (!validationResult.IsValid)
                {
                    return ValidatorErrorResponse(validationResult.Errors);
                }

                User user = await _userService.GetUser(userDto);

                if (user.Username != userDto.Username)
                {
                    return BadRequestResponse("Incorrect User or Password");
                }

                if (!BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash))
                {
                    return BadRequestResponse("Incorrect User or Password");
                }

                string token = CreateToken(user);

                return Ok(token);
            }
            catch (Exception ex)
            {

                return InternalErrorResponse(ex);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
