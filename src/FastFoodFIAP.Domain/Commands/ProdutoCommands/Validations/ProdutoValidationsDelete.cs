namespace FastFoodFIAP.Domain.Commands.ProdutoCommands.Validations
{
    public class ProdutoValidationsDelete:ProdutoValidations<ProdutoDeleteCommand>
    {
        public ProdutoValidationsDelete(){            
            ValidaId();            
        }
    }
}