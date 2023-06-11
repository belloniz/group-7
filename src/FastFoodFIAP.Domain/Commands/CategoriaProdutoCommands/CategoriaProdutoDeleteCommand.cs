using FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands
{
    public class CategoriaProdutoDeleteCommand : CategoriaProdutoCommand
    {
        public CategoriaProdutoDeleteCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new CategoriaProdutoValidationsDelete().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}