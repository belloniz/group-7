using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models
{
    public partial class CategoriaProduto: Entity, IAggregateRoot
    {
        public string Nome { get; private set; } = "";


        private CategoriaProduto() { 
            Produtos = new HashSet<Produto>();
        }

        public CategoriaProduto(int id, string nome){
            Id = id;
            Nome=nome;         
            Produtos = new HashSet<Produto>();   
        }

        public virtual ICollection<Produto> Produtos { get; private set; } 
    }
}

