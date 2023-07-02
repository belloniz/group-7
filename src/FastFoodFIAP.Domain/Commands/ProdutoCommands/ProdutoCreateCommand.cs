using FastFoodFIAP.Domain.Commands.ProdutoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.ProdutoCommands
{
    public class ProdutoCreateCommand:ProdutoCommand
    {
        protected ProdutoCreateCommand(){}

        public ProdutoCreateCommand(string nome, string descricao, decimal preco, Guid categoriaId){
            Nome=nome;
            Descricao=descricao;
            Preco=preco;
            CategoriaId=categoriaId;
        }

        public override bool IsValid()
        {
            ValidationResult = new ProdutoValidationsCreate().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}