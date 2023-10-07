namespace TechChallenge.Domain.Entities
{
    public class UserRole : BaseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

    }
}
