using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.AndamentoCommands
{
    public abstract class AndamentoCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid PedidoId { get; protected set; }
        public DateTime DataHoraInicio { get; protected set; }
        public DateTime? DataHoraFim { get; protected set; }
        public Guid? FuncionarioId { get; protected set; }
        public int SituacaoId { get; protected set; }
        public bool Atual { get; protected set; }
        public AndamentoCommand()
        {

        }
    }
}
