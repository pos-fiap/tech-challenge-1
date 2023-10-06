using TechChallenge.Domain.Enums;

namespace TechChallenge.Application.DTOs
{
    public class RoleDto
    {
        public int Id { get; set; }
        public required string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime AlterDate { get; set; }

    }
}
