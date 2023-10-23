namespace TechChallenge.Application.DTOs
{
    public class ParkingSpotDto
    {
        public required string Description { get; set; }
        public string? Notes { get; set; }
        public required bool Status { get; set; }
    }
}
