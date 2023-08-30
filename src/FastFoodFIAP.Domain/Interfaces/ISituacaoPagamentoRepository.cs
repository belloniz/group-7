
using FastFoodFIAP.Domain.Models;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface ISituacaoPagamentoRepository : IRepository<SituacaoPagamento>
    {
        Task<IEnumerable<SituacaoPagamento>> GetAll();
    }
}
