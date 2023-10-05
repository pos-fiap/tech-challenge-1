using RCLocacoes.Domain.Enums;

namespace RCLocacoes.Domain.Entities
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Roles Role { get; set; } = Roles.User;
    }
}
