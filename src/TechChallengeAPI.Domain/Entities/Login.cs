using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Domain.Entities
{
    public class Login : BaseModel
    {
        public int UserId { get; set; }
        public required string Email { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
        public bool KeepLoggedIn { get; set; }
    }
}
