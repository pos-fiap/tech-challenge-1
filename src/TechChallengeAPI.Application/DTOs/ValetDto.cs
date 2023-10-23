namespace TechChallenge.Application.DTOs
{
    public class ValetDto
    {
        public PersonDTO PersonalInformations { get; set; }
        public int Id { get; set; }
        public string CNH { get; set; }
        public DateTime CNHExpiration { get; set; }
    }
}
