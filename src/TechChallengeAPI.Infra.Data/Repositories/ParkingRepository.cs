using TechChallenge.Domain.Entities;
using TechChallenge.Infra.Data.Context;
using TechChallenge.Infra.Data.Repositories;

namespace TechChallenge.Application.Interfaces
{
    public class ParkingRepository : BaseRepository<Parking>, IParkingRepository
    {
        public ParkingRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}