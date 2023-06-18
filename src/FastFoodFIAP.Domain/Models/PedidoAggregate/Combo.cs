using FastFoodFIAP.Domain.Models.ProdutoAggregate;

namespace FastFoodFIAP.Domain.Models.PedidoAggregate
{
    public class Combo
    {
        public int ComboId { get; private set; }        
        public int ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        
        public virtual Produto? ProdutoNavigation { get; private set; }

        private Combo() { }

        public Combo(int produtoId, int quantidade, decimal valorUnitario){                        
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }
    }
}