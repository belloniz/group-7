using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models.ProdutoAggregate
{
    public partial class Produto : Entity, IAggregateRoot
    {
        public string Nome { get; private set; } = "";
        public string Descricao { get; private set; } = "";
        public decimal Preco { get; private set; }
        public int CategoriaId {get; private set;}
        public ICollection<Imagem>? Imagens { get; private set; }

        public virtual CategoriaProduto? Categoria { get; private set; }

        private Produto() { 
        }

        public Produto(string nome, string descricao, decimal preco, int categoriaId){
            Nome = nome;            
            Descricao = descricao;
            Preco = preco;
            CategoriaId = categoriaId;

            Imagens = new HashSet<Imagem>();
        }
    }
}