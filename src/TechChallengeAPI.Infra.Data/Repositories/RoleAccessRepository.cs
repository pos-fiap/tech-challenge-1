using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Infra.Data.Context;

namespace TechChallenge.Infra.Data.Repositories
{
    public class RoleAccessRepository : BaseRepository<RoleAccess>, IRoleAccessRepository
    {
        public RoleAccessRepository(ApplicationContext context) : base(context)
        {
        }

        public bool HasAccess(int roleId, string route)
        {
            return dbSet.Any(x => x.RoleId == roleId && x.Route.ToLower() == route.ToLower());
        }
    }
}
