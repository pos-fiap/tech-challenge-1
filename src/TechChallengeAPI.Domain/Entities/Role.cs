namespace TechChallenge.Domain.Entities
{
    public class Role : BaseModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime AlterDate { get; set; }
    }
}
