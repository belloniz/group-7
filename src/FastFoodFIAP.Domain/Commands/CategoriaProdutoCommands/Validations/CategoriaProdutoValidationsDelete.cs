namespace FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands.Validations
{
    public class CategoriaProdutoValidationsDelete : CategoriaProdutoValidations<CategoriaProdutoDeleteCommand>
    {
        public CategoriaProdutoValidationsDelete()
        {
            ValidaId();
        }
    }
}