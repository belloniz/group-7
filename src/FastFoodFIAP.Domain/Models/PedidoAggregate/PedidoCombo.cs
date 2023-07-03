using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models.PedidoAggregate
{
    public partial class PedidoCombo : ValueObject
    {
        public int Id { get; private set; }
        public Guid PedidoId { get; private set; }
        public List<PedidoComboProduto> Produtos { get; private set; }
        public int Quantidade { get; private set; }

        public virtual Pedido? PedidoNavegation { get; private set; }

        private PedidoCombo(){
            Produtos = new List<PedidoComboProduto>();
        }

        public PedidoCombo(int quantidade, List<PedidoComboProduto> produtos)
        {
            Quantidade = quantidade;
            Produtos = produtos;
        }        

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}