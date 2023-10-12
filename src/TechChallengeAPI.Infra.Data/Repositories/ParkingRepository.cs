using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Infra.Data.Context;

namespace TechChallenge.Infra.Data.Repositories
{
    public class ParkingRepository : BaseRepository<Parking>, IParkingRepository
    {
        public ParkingRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}