using FastFoodFIAP.Domain.Commands.PagamentoCommands.Validations;
using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.PagamentoCommands{

    public class PagamentoUpdateCommand : PagamentoCommand
    {
        protected PagamentoUpdateCommand(){}

        public PagamentoUpdateCommand(Guid id, int situacaoId){
            Id = id;
            SituacaoId = situacaoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new PagamentoValidationsUpdate().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
