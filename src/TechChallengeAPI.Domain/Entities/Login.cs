using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Domain.Entities
{
    public class Login : BaseModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public bool KeepLoggedIn { get; set; }
    }
}
