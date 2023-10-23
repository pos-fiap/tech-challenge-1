namespace TechChallenge.Domain.Entities
{
    public class CustomerVehicle : BaseModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }

    }
}
