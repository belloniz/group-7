
using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface IProdutoRepository: IRepository<Produto>
    {
        Produto? GetById(int id);
        IEnumerable<Produto> GetAll();
        void Add(Produto produto);
        void Update(Produto produto);
        void Remove(Produto produto);
    }
}