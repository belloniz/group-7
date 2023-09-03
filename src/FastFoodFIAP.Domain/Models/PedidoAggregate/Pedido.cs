using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models.PedidoAggregate
{
    public class Pedido : Entity, IAggregateRoot
    {
        public long? CodigoAcompanhamento { get; private set; }
        public Guid? ClienteId { get; private set;}
        public List<PedidoCombo> Combos { get; private set;} 
        public virtual Cliente? ClienteNavegation { get; set;}
        public virtual Pagamento? PagamentoNavegation { get; private set; }
        
        public virtual ICollection<Andamento>? Andamentos { get; private set; }

        private Pedido() {
            Combos = new List<PedidoCombo>();            
        }

        public Pedido(Guid id, Guid? clienteId){
            Id = id;
            ClienteId = clienteId;

            Combos = new List<PedidoCombo>();            
        }

        public void AddCombo(int quantidade, List<PedidoComboProduto> combos)
        {
            Combos.Add(new PedidoCombo(quantidade, combos));
        }        

        public decimal TotalPedido(){
            decimal Total = 0;            

            foreach (var combo in Combos){
                decimal SubTotalProdutos=0;

                foreach(var produto in combo.Produtos)
                    SubTotalProdutos += produto.ValorUnitario * produto.Quantidade;
                
                Total += SubTotalProdutos * combo.Quantidade;
            }

            return Total;
        }
    }
}