using FastFoodFIAP.Domain.Commands.AndamentoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.AndamentoCommands
{
    public class AndamentoUpdateCommand : AndamentoCommand
    {
        protected AndamentoUpdateCommand() { }

        public AndamentoUpdateCommand(int pedidoId, int funcionarioId, int situacaoId, DateTime dataHoraInicio, DateTime dataHoraFim)
        {            
            PedidoId = pedidoId;
            DataHoraInicio = dataHoraInicio;
            DataHoraFim = dataHoraFim;
            FuncionarioId = funcionarioId;
            SituacaoId = situacaoId;
            DataHoraFim = dataHoraFim;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new AndamentoValidationsUpdate().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
