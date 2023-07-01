using FastFoodFIAP.Domain.Models;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface IAndamentoRepository : IRepository<Andamento>
    {
        Task<Andamento?> GetById(int id);
        void Add(Andamento andamento);
        void Update(Andamento andamento);

    }
}
