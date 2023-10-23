namespace TechChallenge.Domain.Entities
{
    public class Reservation : BaseModel
    {
        public int Id { get; set; }
        public int CustomerVehicleId { get; set; }
        public int ValetId { get; set; }
        public DateTime Entrance { get; set; }
        public DateTime? Exit { get; set; }
        public int TimeParked { get; set; }
        public bool Paid { get; set; }
        public bool Finished { get; set; }
        public int ParkingSpotId { get; set; }

        public virtual Valet Valet { get; set; }
        public virtual CustomerVehicle CustomerVehicle { get; set; }
    }
}
