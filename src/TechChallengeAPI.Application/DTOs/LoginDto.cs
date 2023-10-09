namespace TechChallenge.Application.DTOs
{
    public class LoginDto
    {
        private string _userName = string.Empty;
        private string _password = string.Empty;

        public required string Username { get => _userName; set => _userName = value!.Trim(); }
        public required string Password { get => _password; set => _password = value!.Trim(); }
    }
}
