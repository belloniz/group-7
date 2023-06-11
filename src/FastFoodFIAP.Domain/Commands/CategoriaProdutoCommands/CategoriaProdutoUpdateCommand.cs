using FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands
{
    public class CategoriaProdutoUpdateCommand : CategoriaProdutoCommand
    {
        protected CategoriaProdutoUpdateCommand() { }

        public CategoriaProdutoUpdateCommand(string nome)
        {
            Nome = nome;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new CategoriaProdutoValidationsUpdate().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}