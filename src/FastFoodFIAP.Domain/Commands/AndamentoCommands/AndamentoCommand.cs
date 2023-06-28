using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.AndamentoCommands
{
    public abstract class AndamentoCommand : Command
    {
        public int Id { get; protected set; }
        public int PedidoId { get; protected set; }
        public DateTime DataHoraInicio { get; protected set; }
        public DateTime? DataHoraFim { get; protected set; }
        public int FuncionarioId { get; protected set; }
        public int SituacaoId { get; protected set; }

        public AndamentoCommand()
        {

        }
    }
}
