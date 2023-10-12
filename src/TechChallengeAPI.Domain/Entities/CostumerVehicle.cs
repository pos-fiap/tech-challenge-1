using TechChallenge.Domain.Enums;

namespace TechChallenge.Domain.Entities
{
    public class CostumerVehicle : BaseModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int VehicleId { get; set; }
        public int CostumerId { get; set; }
    }
}
