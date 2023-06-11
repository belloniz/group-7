namespace FastFoodFIAP.Domain.Commands.ProdutoCommands.Validations
{
    public class ProdutoValidationsUpdate:ProdutoValidations<ProdutoUpdateCommand>
    {
        public ProdutoValidationsUpdate(){ 
            ValidaId();           
            ValidaNome();
            ValidaDescricao();
            ValidaPreco();
            ValidaCategoria();
            ValidaExisteImagem();
        }
    }
}