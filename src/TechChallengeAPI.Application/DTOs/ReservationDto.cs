using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int ParkingSpotId { get; set; }
        public int CustomerVehicleId { get; set; }
        public int ValetId { get; set; }
    }
}
