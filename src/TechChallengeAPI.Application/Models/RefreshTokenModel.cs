namespace TechChallenge.Application.Models
{
    public class RefreshTokenModel
    {
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
    }
}
