using FastFoodFIAP.Domain.Models;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface ICategoriaProdutoRepository : IRepository<CategoriaProduto>
    {
        Task<CategoriaProduto?> GetById(int id);
        Task<IEnumerable<CategoriaProduto>> GetAll();
        void Add(CategoriaProduto categoria);
        void Update(CategoriaProduto categoria);
        void Remove(CategoriaProduto categoria);
    }
}
