using GenericPack.Messaging;


namespace FastFoodFIAP.Domain.Events.PagamentoEvents
{
    public class PagamentoUpdateEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Descricao { get; protected set; } = "";
        public decimal Valor { get; protected set; }
        public Guid PedidoId { get; protected set;}
        public int SituacaoId { get; private set; }


        public PagamentoUpdateEvent(Guid pedidoId, string descricao, decimal valor, int situacaoId)
        {
            Id = Guid.NewGuid();
            PedidoId = pedidoId;
            Descricao = descricao;
            Valor = valor;
            SituacaoId = situacaoId;
        }
    }
}
