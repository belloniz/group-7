using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models.PedidoAggregate
{
    public class Pedido : Entity, IAggregateRoot
    {
        public int ClienteId { get; private set;}
        public List<PedidoCombo> PedidoCombos { get; private set;}
        
        //public List<Andamento> Andamentos {get; private set;}

        public virtual Cliente? ClienteNavegation { get; private set;}
        public virtual Pagamento? PagamentoNavegation { get; private set; }
        
        private Pedido() {
            PedidoCombos = new List<PedidoCombo>();
            //Andamentos = new List<Andamento>();
        }

        public Pedido(int id, int clienteId){
            Id = id;
            ClienteId = clienteId;

            PedidoCombos = new List<PedidoCombo>();
            //Andamentos = new List<Andamento>();
        }

        public void AddCombo(int quantidade, PedidoComboProduto? combo)
        {
            PedidoCombos.Add(new PedidoCombo(quantidade, combo));
        }
    }
}