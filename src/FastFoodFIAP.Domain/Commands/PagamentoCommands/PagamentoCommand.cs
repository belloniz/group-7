using FastFoodFIAP.Domain.Models.Pagamento;
using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.PagamentoCommands{
    public class PagamentoCommands : Command
    {
        public Guid Id { get; protected set; }
        public Guid? ClienteId {get; protected set;}
       
    }
}
