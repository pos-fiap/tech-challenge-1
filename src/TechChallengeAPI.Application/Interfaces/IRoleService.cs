using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IRoleService
    {
        Task<BaseOutput<List<Role>>> GetAllRoles();
        Task<BaseOutput<Role>> GetRoleById(int Id);
        Task<BaseOutput<Role>> GetRole(RoleDto roleDto);
        Task<BaseOutput<int>> RegisterRole(RoleDto roleDto);
        Task<BaseOutput<Role>> UpdateRole(RoleDto roleDto);
        Task<List<int>> VerifyListRole(List<int> ListId);
        Task<bool> VerifyRole(string rolename);
        Task<bool> VerifyRole(int Id);
        Task<BaseOutput<bool>> DeleteRole(int Id);

    }
}