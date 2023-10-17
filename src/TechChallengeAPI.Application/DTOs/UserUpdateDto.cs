namespace TechChallenge.Application.DTOs
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

    }
}
