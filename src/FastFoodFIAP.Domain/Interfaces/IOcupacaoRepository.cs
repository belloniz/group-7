using FastFoodFIAP.Domain.Models;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface IOcupacaoRepository : IRepository<Ocupacao>
    {
        Task<Ocupacao?> GetById(int id);
        Task<IEnumerable<Ocupacao>> GetAll();
        void Add(Ocupacao ocupacao);
        void Update(Ocupacao ocupacao);
        void Remove(Ocupacao ocupacao);
    }
}
