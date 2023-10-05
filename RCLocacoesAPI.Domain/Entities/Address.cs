namespace RCLocacoes.Domain.Entities
{
    public class Address : BaseModel
    {

        public int Id { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string AdditionalDetails { get; set; } = string.Empty;
    }
}
