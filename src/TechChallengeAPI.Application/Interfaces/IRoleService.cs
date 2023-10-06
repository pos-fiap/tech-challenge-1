using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IRoleService
    {
        Task<Role> GetRole(int Id);
        Task<BaseOutput<int>> RegisterRole(RoleDto roleDto);
        Task<bool> VerifyRole(RoleDto roleDto);

    }
}