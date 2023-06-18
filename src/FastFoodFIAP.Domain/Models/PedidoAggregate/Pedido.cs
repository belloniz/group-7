using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models.PedidoAggregate
{
    public class Pedido : Entity, IAggregateRoot
    {
        public int ClienteId {get; private set;}
        public List<PedidoItem> Itens {get; private set;}
        //public List<Andamento> Andamentos {get; private set;}

        public virtual Cliente? ClienteNavegation { get; private set; }
        //public virtual Pagamento? PagamentoNavegation { get; private set; }
        
        private Pedido() {
            Itens = new List<PedidoItem>();
            //Andamentos = new List<Andamento>();
        }

        public Pedido(int id, int clienteId){
            Id = id;
            ClienteId = clienteId;

            Itens = new List<PedidoItem>();
            //Andamentos = new List<Andamento>();
        }

        public void AddItem(int quantidade, Combo? combo)
        {
            Itens.Add(new PedidoItem(quantidade, combo));
        }
    }
}