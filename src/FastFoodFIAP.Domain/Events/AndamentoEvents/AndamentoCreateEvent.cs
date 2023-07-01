using GenericPack.Messaging;


namespace FastFoodFIAP.Domain.Events.AndamentoEvents
{
    public class AndamentoCreateEvent:Event
    {
        public int PedidoId { get; set; }
        public DateTime DataHoraInicio { get; protected set; }
        public DateTime? DataHoraFim { get; protected set; }
        public int? FuncionarioId { get; protected set; }
        public int SituacaoId { get; protected set; }

        public AndamentoCreateEvent(int pedidoId, int? funcionarioId, int situacaoId)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            DataHoraInicio = this.Timestamp;
            DataHoraFim = null;
            FuncionarioId = funcionarioId;
            SituacaoId = situacaoId;
        }
    }
}
