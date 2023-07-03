using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models.PedidoAggregate
{
    public class PedidoComboProduto : ValueObject
    {
        public int PedidoComboId { get; private set; }        
        public Guid ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public virtual PedidoCombo? PedidoComboNavigation { get; private set; }
        public virtual Produto? ProdutoNavigation { get; private set; }

        private PedidoComboProduto() { }

        public PedidoComboProduto(Guid produtoId, int quantidade, decimal valorUnitario){                        
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PedidoComboId;
            yield return ProdutoId;
        }

    }
}