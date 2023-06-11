namespace FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands.Validations
{
    public class CategoriaProdutoValidationsCreate : CategoriaProdutoValidations<CategoriaProdutoCreateCommand>
    {
        public CategoriaProdutoValidationsCreate()
        {
            ValidaNome();
        }
    }
}