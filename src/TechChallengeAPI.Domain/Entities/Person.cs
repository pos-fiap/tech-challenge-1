namespace TechChallenge.Domain.Entities
{
    public class Person : BaseModel
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }

    }
}
