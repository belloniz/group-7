using FastFoodFIAP.Domain.Commands.ProdutoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.ProdutoCommands
{
    public class ProdutoUpdateCommand:ProdutoCommand
    {
        protected ProdutoUpdateCommand(){}

        public ProdutoUpdateCommand(string nome, string descricao, decimal preco, Guid categoriaId){
            Nome=nome;
            Descricao=descricao;
            Preco=preco;
            CategoriaId=categoriaId;
        }

        public void SetId(Guid id){
            Id=id;
        }
        
        public override bool IsValid()
        {
            CommandResult.ValidationResult = new ProdutoValidationsUpdate().Validate(this);
            return CommandResult.ValidationResult.IsValid;
        }
    }
}