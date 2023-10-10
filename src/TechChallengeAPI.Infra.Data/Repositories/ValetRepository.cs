using TechChallenge.Domain.Entities;
using TechChallenge.Infra.Data.Context;
using TechChallenge.Infra.Data.Repositories;

namespace TechChallenge.Application.Interfaces
{
    public class ValetRepository : BaseRepository<Valet>, IValetRepository
    {
        public ValetRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}