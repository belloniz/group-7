using FastFoodFIAP.Domain.Models;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface ICategoriaProdutoRepository: IRepository<CategoriaProduto>
    {
        CategoriaProduto? GetById(int id);
        IEnumerable<CategoriaProduto> GetAll();
        void Add(CategoriaProduto categoria);
        void Update(CategoriaProduto categoria);
        void Remove(CategoriaProduto categoria);
    }
}