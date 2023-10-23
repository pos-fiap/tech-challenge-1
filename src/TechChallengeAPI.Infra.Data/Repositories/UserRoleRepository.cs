using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Infra.Data.Context;

namespace TechChallenge.Infra.Data.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<UserRole> GetRoleByUsername(string username)
        {
            return await dbSet
                .Include(x => x.Role)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.User.Username == username);
        }
    }
}