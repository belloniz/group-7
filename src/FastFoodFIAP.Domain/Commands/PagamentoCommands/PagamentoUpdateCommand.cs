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
            CommandResult.ValidationResult = new PagamentoValidationsUpdate().Validate(this);
            return CommandResult.ValidationResult.IsValid;
        }
    }
}

