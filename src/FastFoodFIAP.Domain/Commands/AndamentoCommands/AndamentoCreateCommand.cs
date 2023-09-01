using FastFoodFIAP.Domain.Commands.AndamentoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.AndamentoCommands
{
    public class AndamentoCreateCommand : AndamentoCommand
    {
        public AndamentoCreateCommand(Guid pedidoId, Guid funcionarioId, int situacaoId)
        {            
            PedidoId = pedidoId;
            DataHoraInicio=DateTime.Now;
            DataHoraFim = null;
            FuncionarioId = funcionarioId;
            SituacaoId = situacaoId;
            Atual = true;
        }

        public override bool IsValid()
        {
            CommandResult.ValidationResult = new AndamentoValidationsCreate().Validate(this);
            return CommandResult.ValidationResult.IsValid;
        }
    }
}
