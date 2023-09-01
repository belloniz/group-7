using FastFoodFIAP.Domain.Commands.AndamentoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.AndamentoCommands
{
    public class AndamentoUpdateCommand : AndamentoCommand
    {
        protected AndamentoUpdateCommand() { }

        public AndamentoUpdateCommand(Guid pedidoId, Guid funcionarioId, int situacaoId, DateTime dataHoraInicio, DateTime dataHoraFim, bool atual)
        {            
            PedidoId = pedidoId;
            DataHoraInicio = dataHoraInicio;
            DataHoraFim = dataHoraFim;
            FuncionarioId = funcionarioId;
            SituacaoId = situacaoId;
            DataHoraFim = dataHoraFim;
            Atual = atual;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            CommandResult.ValidationResult = new AndamentoValidationsUpdate().Validate(this);
            return CommandResult.ValidationResult.IsValid;
        }
    }
}
