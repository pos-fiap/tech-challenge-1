using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(int Id);
        Task<User> GetUser(UserDto userDto);
        Task<BaseOutput<int>> RegisterUser(UserDto userDto);
        Task<bool> VerifyUser(UserDto userDto);

    }
}