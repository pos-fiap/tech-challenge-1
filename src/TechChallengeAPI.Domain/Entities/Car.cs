namespace TechChallenge.Domain.Entities
{
    public class Car : BaseModel
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Plate { get; set; }
        public virtual ICollection<Parking>? ParkingLots { get; set; }
    }
}
