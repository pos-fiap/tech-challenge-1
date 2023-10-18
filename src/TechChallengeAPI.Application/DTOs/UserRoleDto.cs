using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.DTOs
{
    public class UserRoleDto
    {
        public int UserId { get; set; }
        public IList<Role> Roles { get; set; }
    }
}
