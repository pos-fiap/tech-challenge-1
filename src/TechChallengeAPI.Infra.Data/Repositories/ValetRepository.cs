using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Infra.Data.Context;

namespace TechChallenge.Infra.Data.Repositories
{
    public class ValetRepository : BaseRepository<Valet>, IValetRepository
    {
        public ValetRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}