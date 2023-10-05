using RCLocacoes.Domain.Enums;

namespace RCLocacoes.Application.DTOs
{
    public class UserDto
    {
        private string _userName = string.Empty;
        private string _password = string.Empty;

        public int Id { get; set; }
        public required string Username { get => _userName; set => _userName = value!.Trim(); }
        public required string Password { get => _password; set => _password = value!.Trim(); }
        public Roles Role { get; set; } = Roles.User;

    }
}
