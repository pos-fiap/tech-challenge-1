namespace TechChallenge.Application.DTOs
{
    public class UserDto
    {
        public PersonDTO PersonalInformations { get; set; }
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

    }
}
