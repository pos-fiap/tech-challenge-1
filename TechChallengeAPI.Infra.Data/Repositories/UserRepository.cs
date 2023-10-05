using RCLocacoes.Domain.Entities;
using RCLocacoes.Infra.Data.Context;

namespace RCLocacoes.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
