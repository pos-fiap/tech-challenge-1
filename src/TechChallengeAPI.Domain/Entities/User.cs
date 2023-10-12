namespace TechChallenge.Domain.Entities
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryDate { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

    }
}
