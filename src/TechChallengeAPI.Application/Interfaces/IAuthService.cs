using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Models;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
        RefreshTokenModel GenerateRefreshToken();
        BaseOutput<string> ValidateLogin(User user, LoginDto loginDto);
        Task<BaseOutput<TokenDto>> RefreshExpiratedTokenAsync(TokenDto tokenDto);

    }
}
