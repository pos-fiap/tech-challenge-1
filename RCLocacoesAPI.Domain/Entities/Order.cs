namespace RCLocacoes.Domain.Entities
{
    public class Order : BaseModel
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public int ClientId { get; set; }
        public int ClientDependentId { get; set; }
        public DateTime ExpiratonDate { get; set; }
        public DateTime ReservationInitialDate { get; set; }
        public DateTime ReservationFinalDate { get; set; }
        public int LocalId { get; set; }
        public string? Observacao { get; set; }

        public Client? Client { get; set; }
        public Status? Status { get; set; }
        public Local? Local { get; set; }

    }
}
