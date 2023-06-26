using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models.PedidoAggregate
{
    public partial class PedidoCombo : ValueObject
    {
        public int Id { get; private set; }
        public int PedidoId { get; private set; }
        public PedidoComboProduto? PedidoComboProduto { get; private set; }
        public int Quantidade { get; private set; }

        public virtual Pedido? PedidoNavegation { get; private set; }

        private PedidoCombo(){
        }

        public PedidoCombo(int quantidade, PedidoComboProduto? combo)
        {
            Quantidade = quantidade;
            PedidoComboProduto = combo;
        }        

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}