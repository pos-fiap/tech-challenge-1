﻿using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
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

        bool ValidateToken(string token);

        (ClaimsPrincipal, SecurityToken) GetClaimsPrincipal(string token);

        Task<BaseOutput<TokenDto>> RefreshExpiratedTokenAsync(TokenDto tokenDto);

    }
}
