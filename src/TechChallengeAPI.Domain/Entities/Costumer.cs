namespace TechChallenge.Domain.Entities
{
    public class Costumer : BaseModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
