using FastFoodFIAP.Domain.Commands.ProdutoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.ProdutoCommands
{
    public class ProdutoDeleteCommand:ProdutoCommand
    {
        public ProdutoDeleteCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new ProdutoValidationsDelete().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}