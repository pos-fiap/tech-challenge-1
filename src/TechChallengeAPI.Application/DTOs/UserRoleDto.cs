namespace TechChallenge.Application.DTOs
{
    public class UserRoleDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public IList<int> RoleIds { get; set; } = new List<int>();
    }
}
