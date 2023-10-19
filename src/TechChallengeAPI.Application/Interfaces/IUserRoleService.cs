using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IUserRoleService
    {
        Task<BaseOutput<IList<UserRole>>> GetByUser(int user);
        Task<BaseOutput<int>> AssignRoleToUser(UserRoleDto userRoleDto);

        Task<UserRole> GetRoleByUsername(string username);
    }
}