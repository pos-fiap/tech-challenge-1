using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IUserRoleService
    {
        Task<BaseOutput<UserRole>> GetRolesByUser(int user);
        Task<BaseOutput<int>> AssignRoleToUser(UserRoleDto userRoleDto);
        Task<BaseOutput<int>> UnassignRoleToUser(UserRoleDto userRoleDto);

    }
}