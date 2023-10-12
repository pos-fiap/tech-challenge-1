namespace TechChallenge.Domain.Entities
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public string? Notes { get; set; }
        public required bool Status { get; set; }
    }
}
