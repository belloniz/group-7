
using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface IProdutoRepository: IRepository<Produto>
    {
        Task<Produto?> GetById(Guid id);
        Task<IEnumerable<Produto>> GetAll();
        Task<IEnumerable<Produto>> GetAllByCategoria(Guid categoriaId);
        void Add(Produto produto);
        void Update(Produto produto);
        void Remove(Produto produto);
    }
}
