using FastFoodFIAP.Domain.Commands.ProdutoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.ProdutoCommands
{
    public class ProdutoUpdateCommand:ProdutoCommand
    {
        protected ProdutoUpdateCommand(){}

        public ProdutoUpdateCommand(string nome, string descricao, decimal preco, int categoriaId){
            Nome=nome;
            Descricao=descricao;
            Preco=preco;
            CategoriaId=categoriaId;
        }

        public void SetId(int id){
            Id=id;
        }
        public override bool IsValid()
        {
            ValidationResult = new ProdutoValidationsUpdate().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}