using RCLocacoes.Application.BaseResponse;
using RCLocacoes.Application.DTOs;
using RCLocacoes.Domain.Entities;

namespace RCLocacoes.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(int Id);
        Task<User> GetUser(UserDto userDto);
        Task<BaseOutput<int>> RegisterUser(UserDto userDto);
        Task<bool> VerifyUser(UserDto userDto);

    }
}