using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Infra.Data.Context;

namespace TechChallenge.Infra.Data.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ApplicationContext context) : base(context)
        {
        }
    }
}