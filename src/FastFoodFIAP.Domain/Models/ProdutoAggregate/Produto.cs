using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models.ProdutoAggregate
{
    public partial class Produto : Entity, IAggregateRoot
    {
        public string Nome { get; private set; } = "";
        public string Descricao { get; private set; } = "";
        public decimal Preco { get; private set; }
        public Guid CategoriaId {get; private set;}
        
        public virtual ICollection<Imagem> Imagens { get; private set; }
        public virtual CategoriaProduto? CategoriaNavegation { get; private set; }

        private Produto() {
            Imagens = new HashSet<Imagem>();
        }

        public Produto(Guid id, string nome, string descricao, decimal preco, Guid categoriaId){
            Id = id;
            Nome = nome;            
            Descricao = descricao;
            Preco = preco;
            CategoriaId = categoriaId;

            Imagens = new HashSet<Imagem>();
        }

        public void AddImagem(string url)
        {
            Imagens.Add(new Imagem(url));
        }
    }
}
