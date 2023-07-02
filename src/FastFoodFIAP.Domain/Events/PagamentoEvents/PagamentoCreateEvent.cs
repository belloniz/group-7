using GenericPack.Messaging;


namespace FastFoodFIAP.Domain.Events.PagamentoEvents
{
    public class PagamentoCreateEvent : Event
    {
        public Guid Id { get; protected set; }
        public string QrCode { get; protected set; } = "";
        public decimal Valor { get; protected set; }
        public Guid PedidoId { get; protected set;}

        public PagamentoCreateEvent(Guid pedidoId, string qrCode, decimal valor)
        {
            Id = Guid.NewGuid();
            PedidoId = pedidoId;
            QrCode = qrCode;
            Valor = valor;
        }
    }
}
