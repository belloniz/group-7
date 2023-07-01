using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.ClienteCommands
{
    public abstract class ClienteCommand : Command
    {
        public int Id { get; protected set; }
        public string? Nome { get; protected set; } 
        public string? Email { get; protected set; }
        public string? Cpf { get; protected set; }
    }
}