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
            CommandResult.ValidationResult = new CategoriaProdutoValidationsCreate().Validate(this);
            return CommandResult.ValidationResult.IsValid;
        }
    }
}