using GenericPack.Messaging;


namespace FastFoodFIAP.Domain.Events.AndamentoEvents
{
    public class AndamentoCreateEvent:Event
    {
        public Guid Id { get; protected set; }
        public Guid PedidoId { get; set; }
        public DateTime DataHoraInicio { get; protected set; }
        public DateTime? DataHoraFim { get; protected set; }
        public Guid? FuncionarioId { get; protected set; }
        public int SituacaoId { get; protected set; }
        public bool Atual { get; protected set; }

        public AndamentoCreateEvent(Guid pedidoId, Guid? funcionarioId, int situacaoId, bool atual)
        {
            Id = Guid.NewGuid();
            PedidoId = pedidoId;
            DataHoraInicio = this.Timestamp;
            DataHoraFim = this.Timestamp;
            FuncionarioId = funcionarioId;
            SituacaoId = situacaoId;
            Atual = atual;
        }
    }
}
