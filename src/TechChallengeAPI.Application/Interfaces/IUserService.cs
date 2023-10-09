using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Models;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IUserService
    {
        Task<BaseOutput<List<User>>> GetAllUsers();
        Task<BaseOutput<User>> GetUser(int Id);
        Task<BaseOutput<User>> GetUser(UserDto userDto);
        Task<BaseOutput<int>> RegisterUser(UserDto userDto);
        Task<BaseOutput<User>> UpdateUser(UserDto userDto);
        Task<bool> VerifyUser(string username);
        Task<bool> VerifyUser(int Id);
        Task<BaseOutput<bool>> DeleteUser(int Id);

        Task<User> GetUserByUsername(string username);
        Task<BaseOutput<User>> GetUserByLogin(LoginDto userDto);
        Task UpdateUserRefreshToken(User user, RefreshTokenModel tokenModel);

    }
}