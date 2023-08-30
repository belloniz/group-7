using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.PagamentoCommands{
    public class PagamentoCommands : Command
    {
        public Guid Id { get; protected set; }
        
        public int SituacaoId { get; protected set; }
    
    }
}
