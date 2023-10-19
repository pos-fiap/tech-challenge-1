using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces
{
    public interface IRoleAccessRepository : IBaseRepository<RoleAccess>
    {
        bool HasAccess(int roleId, string route);
    }
}
