using FastFoodFIAP.Domain.Commands.ProdutoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.ProdutoCommands
{
    public class ProdutoDeleteCommand:ProdutoCommand
    {
        public ProdutoDeleteCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            CommandResult.ValidationResult = new ProdutoValidationsDelete().Validate(this);
            return CommandResult.ValidationResult.IsValid;
        }
    }
}