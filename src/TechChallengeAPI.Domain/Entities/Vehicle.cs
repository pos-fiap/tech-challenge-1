using TechChallenge.Domain.Enums;

namespace TechChallenge.Domain.Entities
{
    public class Vehicle : BaseModel
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string LicensePlate { get; set; }
        public VehicleType VehicleType { get; set; }
        public string? Notes { get; set; }
        public virtual ICollection<ParkingSpot>? ParkingLots { get; set; }
    }
}
