using FastFoodFIAP.Domain.Commands.ProdutoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.ProdutoCommands
{
    public class ProdutoUpdateCommand:ProdutoCommand
    {
        protected ProdutoUpdateCommand(){}

        public ProdutoUpdateCommand(int id, string nome, string descricao, decimal preco, int categoriaId){
            Id=id;
            Nome=nome;
            Descricao=descricao;
            Preco=preco;
            CategoriaId=categoriaId;
        }

        public override bool IsValid()
        {
            ValidationResult = new ProdutoValidationsUpdate().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}