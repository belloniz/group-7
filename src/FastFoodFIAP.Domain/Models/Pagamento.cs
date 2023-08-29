using FastFoodFIAP.Domain.Models.PedidoAggregate;
using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models
{
    public class Pagamento : Entity, IAggregateRoot
    {
        public String QrCode { get; private set; } = "";
        public decimal Valor { get; private set; }
        public Guid PedidoId { get; private set; }
        public int SituacaoId { get; private set; }

        public virtual Pedido PedidoNavegation { get; private set; }

        private Pagamento() { }

        public Pagamento(Guid id, String qrCode, decimal valor, Guid pedidoId, int situacaoId)
        {
            Id = id;
            QrCode = qrCode;
            Valor = valor;
            PedidoId = pedidoId;
            SituacaoId = situacaoId;
        }
    }
}
