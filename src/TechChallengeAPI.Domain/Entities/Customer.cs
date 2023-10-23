namespace TechChallenge.Domain.Entities
{
    public class Customer : BaseModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
