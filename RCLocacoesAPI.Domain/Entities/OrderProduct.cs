namespace RCLocacoes.Domain.Entities
{
    public class OrderProduct : BaseModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal RentPrice { get; set; }
        public decimal ReplacementCost { get; set; }
        public int Quantity { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }

    }
}
