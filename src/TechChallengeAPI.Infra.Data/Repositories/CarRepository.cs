using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Infra.Data.Context;
using TechChallenge.Infra.Data.Repositories;

namespace TechChallenge.Application.Interfaces
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}