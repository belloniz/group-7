namespace FastFoodFIAP.Domain.Commands.ProdutoCommands.Validations
{
    public class ProdutoValidationsCreate:ProdutoValidations<ProdutoCreateCommand>
    {
        public ProdutoValidationsCreate(){            
            ValidaNome();
            ValidaDescricao();
            ValidaPreco();
            ValidaCategoria();
        }
    }
}