using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models.PedidoAggregate
{
    public class Pagamento: Entity, IAggregateRoot
    {       
        public String? QrCode { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Valor { get; private set; }
        public virtual Pedido? Pedido { get; private set; }

        private Pagamento() { }

        public Pagamento(int id, String qrCode, decimal valor){    
            Id = id;                    
            QrCode = qrCode;
            Valor = valor;
        }
    }
}
