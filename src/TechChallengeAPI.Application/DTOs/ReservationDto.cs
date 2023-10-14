using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int ParkingSpotId { get; set; }
        public int CustomerVehicleId { get; set; }
        public DateTime Entrance { get; set; }
        public DateTime Exit { get; set; }
        public int TimeParked { get; set; }
        public bool Paid { get; set; }
        public bool Finished { get; set; }
    }
}
