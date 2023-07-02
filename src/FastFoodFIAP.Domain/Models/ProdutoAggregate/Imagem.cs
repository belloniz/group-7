using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models.ProdutoAggregate
{
    public partial class Imagem : ValueObject
    {
        public int Id { get; private set; }
        public string Url { get; private set; } = "";
        public Guid ProdutoId { get; private set; }


        public virtual Produto? ProdutoNavigation { get; private set; }

        private Imagem() { }

        public Imagem(string url){                        
            Url = url;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Url;
            yield return ProdutoId;
        }
    }
}