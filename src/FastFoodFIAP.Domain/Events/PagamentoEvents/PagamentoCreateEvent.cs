using FastFoodFIAP.Domain.Models.PedidoAggregate;
using GenericPack.Messaging;


namespace FastFoodFIAP.Domain.Events.PagamentoEvents
{
    public class PagamentoCreateEvent : Event
    {
        public Guid Id { get; protected set; }
        public Pedido Pedido { get; protected set;}

        public PagamentoCreateEvent(Pedido pedido)
        {
            Id = Guid.NewGuid();
            Pedido = pedido;
        }
    }
}
