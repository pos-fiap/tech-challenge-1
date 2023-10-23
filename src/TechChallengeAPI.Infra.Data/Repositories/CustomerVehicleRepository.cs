using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Infra.Data.Context;

namespace TechChallenge.Infra.Data.Repositories
{
    public class CustomerVehicleRepository : BaseRepository<CustomerVehicle>, ICustomerVehicleRepository
    {
        public CustomerVehicleRepository(ApplicationContext context) : base(context)
        {
        }
    }
}