namespace RCLocacoes.Domain.Entities
{
    public class Client : BaseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public char Nationality { get; set; }
        public string? Document { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int ClientTypeId { get; set; }
        public string? Cellphone { get; set; }
        public int AddressId { get; set; }

        public virtual ClientType? ClientType { get; set; }
        public virtual Address? Address { get; set; }
    }
}
