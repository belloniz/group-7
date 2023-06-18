using FastFoodFIAP.Domain.Models.PedidoAggregate;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface IPedidoRepository: IRepository<Pedido>
    {
        Task<Pedido?> GetById(int id);
        Task<IEnumerable<Pedido>> GetAll();
        void Add(Pedido pedido);
        void Update(Pedido pedido);
        void Remove(Pedido pedido);
    }
}