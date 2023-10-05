namespace RCLocacoes.Domain.Entities
{
    public class Product : BaseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal RentPrice { get; set; }
        public decimal ReplacementCost { get; set; }
        public bool Inactive { get; set; }
        public string? Picture { get; set; }
    }
}
