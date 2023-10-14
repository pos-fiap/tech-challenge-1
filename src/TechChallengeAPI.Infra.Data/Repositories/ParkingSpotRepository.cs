using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Infra.Data.Context;

namespace TechChallenge.Infra.Data.Repositories
{
    public class ParkingSpotRepository : BaseRepository<ParkingSpot>, IParkingSpotRepository
    {
        public ParkingSpotRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}