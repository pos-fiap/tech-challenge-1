namespace TechChallenge.Domain.Entities
{
    public class Valet : BaseModel
    {
        public int Id { get; set; }
        public string CNH { get; set; }
        public DateTime? CNHExpiration { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

    }
}
