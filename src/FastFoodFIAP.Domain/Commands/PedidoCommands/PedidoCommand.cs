using FastFoodFIAP.Domain.Models.PedidoAggregate;
using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.PedidoCommands{
    public class PedidoCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid? ClienteId {get; protected set;}
        public long CodigoAcompanhamento { get; set; }
        public List<PedidoCombo> Combos { get; protected set;}

        public PedidoCommand(){
            Combos = new List<PedidoCombo>();
        }
    }
}
