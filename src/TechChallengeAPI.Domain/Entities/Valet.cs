using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Domain.Entities
{
    public class Valet : BaseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Parking>? ParkingLots { get; set; }

    }
}
