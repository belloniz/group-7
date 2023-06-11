using FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands
{
    public class CategoriaProdutoCreateCommand : CategoriaProdutoCommand
    {
        public CategoriaProdutoCreateCommand(string nome)
        {
            Nome = nome;
        }

        public override bool IsValid()
        {
            ValidationResult = new CategoriaProdutoValidationsCreate().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}