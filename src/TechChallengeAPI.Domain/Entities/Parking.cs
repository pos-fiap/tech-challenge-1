namespace TechChallenge.Domain.Entities
{
    public class Parking : BaseModel
    {
        public int Id { get; set; }
        public int ValetId { get; set; }
        public int CarId { get; set; }
        public Valet? Valet { get; set; }
        public Car? Car { get; set; }
    }
}
