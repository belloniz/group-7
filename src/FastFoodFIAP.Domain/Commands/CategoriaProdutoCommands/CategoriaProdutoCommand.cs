using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands
{
    public abstract class CategoriaProdutoCommand:Command
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; } = "";

        public CategoriaProdutoCommand() {
        
        }
    }
}