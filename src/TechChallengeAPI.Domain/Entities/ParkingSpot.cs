﻿namespace TechChallenge.Domain.Entities
{
    public class ParkingSpot : BaseModel
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public string? Notes { get; set; }
        public required bool Status { get; set; }

        public virtual IEnumerable<Reservation> Reservations { get; set; }
    }
}
