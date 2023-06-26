using FastFoodFIAP.Domain.Models.PedidoAggregate;
using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.PedidoCommands{
    public class PedidoCommand : Command
    {
        public int Id { get; protected set; }
        public int ClienteId {get; protected set;}
        public List<PedidoCombo> Itens {get; protected set;}

        public PedidoCommand(){
            Itens = new List<PedidoCombo>();
        }
    }
}
