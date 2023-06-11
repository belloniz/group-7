using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.ProdutoCommands
{
    public abstract class ProdutoCommand: Command
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; } = "";
        public string Descricao { get; protected set; } = "";
        public decimal Preco { get; protected set; }
        public int CategoriaId {get; protected set;}
        public List<string> ImagensUrl{get; protected set;} 

        public ProdutoCommand(){
            ImagensUrl = new List<string>();
        }
    }
}