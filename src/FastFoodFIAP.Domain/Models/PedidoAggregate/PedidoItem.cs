using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models.PedidoAggregate
{
    public partial class PedidoItem : ValueObject
    {
        public int Id { get; private set; }
        public int PedidoId { get; private set; }
        public Combo? Combo { get; private set; }
        public int Quantidade { get; private set; }


        private PedidoItem(){
        }

        public PedidoItem(int quantidade, Combo? combo)
        {
            Quantidade = quantidade;            
            Combo = combo;
        }        

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}