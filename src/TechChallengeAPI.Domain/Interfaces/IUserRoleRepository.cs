using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces
{
    public interface IUserRoleRepository : IBaseRepository<UserRole>
    {
        Task<UserRole> GetRoleByUsername(string username);

    }
}
