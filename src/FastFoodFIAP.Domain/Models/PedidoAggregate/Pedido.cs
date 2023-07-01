using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models.PedidoAggregate
{
    public class Pedido : Entity, IAggregateRoot
    {
        public int? ClienteId { get; private set;}
        public List<PedidoCombo> Combos { get; private set;} 
        public virtual Cliente? ClienteNavegation { get; private set;}
        public virtual Pagamento? PagamentoNavegation { get; private set; }
        
        public virtual ICollection<Andamento>? Andamentos { get; private set; }

        private Pedido() {
            Combos = new List<PedidoCombo>();            
        }

        public Pedido(int id, int? clienteId){
            Id = id;
            ClienteId = clienteId;

            Combos = new List<PedidoCombo>();            
        }

        public void AddCombo(int quantidade, List<PedidoComboProduto> combos)
        {
            Combos.Add(new PedidoCombo(quantidade, combos));
        }
    }
}