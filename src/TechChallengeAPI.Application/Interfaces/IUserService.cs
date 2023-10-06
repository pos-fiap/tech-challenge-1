using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Models;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(int Id);

        Task<User> GetUserByUsername(string username);
        Task<BaseOutput<User>> GetUserByLogin(LoginDto userDto);
        Task<BaseOutput<int>> RegisterUser(UserDto userDto);
        Task<bool> VerifyUser(UserDto userDto);
        Task UpdateUserRefreshToken(User user, RefreshTokenModel tokenModel);

    }
}