
using FastFoodFIAP.Domain.Models;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface ISituacaoPedidoRepository : IRepository<SituacaoPedido>
    {
        Task<IEnumerable<SituacaoPedido>> GetAll();
    }
}