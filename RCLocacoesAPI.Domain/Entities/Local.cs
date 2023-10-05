namespace RCLocacoes.Domain.Entities
{
    public class Local : BaseModel
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public string? Name { get; set; }
        public string? Note { get; set; }
        public string? Contact { get; set; }

        public virtual Address? Address { get; set; }
    }
}
