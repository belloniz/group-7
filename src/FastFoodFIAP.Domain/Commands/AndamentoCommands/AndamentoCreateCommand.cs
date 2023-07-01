using FastFoodFIAP.Domain.Commands.AndamentoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.AndamentoCommands
{
    public class AndamentoCreateCommand : AndamentoCommand
    {
        public AndamentoCreateCommand(int pedidoId, int funcionarioId, int situacaoId)
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
            ValidationResult = new AndamentoValidationsCreate().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
