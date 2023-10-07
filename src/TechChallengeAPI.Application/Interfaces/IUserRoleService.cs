using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IUserRoleService
    {
        Task<BaseOutput<UserRole>> GetRolesByUser(int user);
        Task<BaseOutput<bool>> AssignRoleToUser(UserRoleDto userRoleDto);
        Task<BaseOutput<bool>> UnassignRoleToUser(UserRoleDto userRoleDto);

    }
}