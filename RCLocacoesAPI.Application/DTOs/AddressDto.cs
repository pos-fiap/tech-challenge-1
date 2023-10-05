namespace RCLocacoes.Application.DTOs
{
    public class AddressDto
    {
        public int? Id { get; set; }
        public int? ZipCode { get; set; }
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string AdditionalDetails { get; set; } = string.Empty;
    }
}
