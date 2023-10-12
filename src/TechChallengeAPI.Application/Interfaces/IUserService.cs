using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Models;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IUserService
    {
        Task<BaseOutput<int>> RegisterUser(UserDto userDto);
        Task<BaseOutput<User>> UpdateUser(UserDto userDto);
        Task<bool> VerifyUser(string username);
        Task<bool> VerifyUser(int Id);
        Task<BaseOutput<bool>> DeleteUser(int Id);

        Task<BaseOutput<List<User>>> GetAllUsers();
        Task<BaseOutput<User>> GetUser(int Id);
        Task<BaseOutput<User>> GetUser(UserDto userDto);
        Task<User> GetUser(string username);
        Task<BaseOutput<User>> GetUser(LoginDto userDto);
        Task UpdateUserRefreshToken(User user, RefreshTokenModel tokenModel);

    }
}