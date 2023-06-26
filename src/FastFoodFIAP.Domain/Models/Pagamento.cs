using FastFoodFIAP.Domain.Models.PedidoAggregate;
using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models
{
    public class Pagamento: Entity, IAggregateRoot
    {       
        public String QrCode { get; private set; } = "";
        public decimal Valor { get; private set; }
        public int PedidoId { get; private set;}

        public virtual Pedido? PedidoNavegation { get; private set; }

        private Pagamento() {}

        public Pagamento(int id, String qrCode, decimal valor, int pedidoId){    
            Id = id;                    
            QrCode = qrCode;
            Valor = valor;
            PedidoId = pedidoId;
        }
    }
}
