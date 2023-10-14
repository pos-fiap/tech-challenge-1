using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.DTOs
{
    public class CustomerVehicleDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
    }
}
