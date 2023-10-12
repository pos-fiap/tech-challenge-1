using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Infra.Data.Context;

namespace TechChallenge.Infra.Data.Repositories
{
    public class CostumerRepository : BaseRepository<Costumer>, ICostumerRepository
    {
        public CostumerRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
