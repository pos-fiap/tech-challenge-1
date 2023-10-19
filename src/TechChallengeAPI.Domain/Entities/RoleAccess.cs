namespace TechChallenge.Domain.Entities
{
    public class RoleAccess : BaseModel
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string Route { get; set; }

        public virtual Role Role { get; set; }
    }
}
