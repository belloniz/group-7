using FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands
{
    public class CategoriaProdutoDeleteCommand : CategoriaProdutoCommand
    {
        public CategoriaProdutoDeleteCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            CommandResult.ValidationResult = new CategoriaProdutoValidationsDelete().Validate(this);
            return CommandResult.ValidationResult.IsValid;
        }
    }
}