using FastFoodFIAP.Domain.Models.PedidoAggregate;
using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface IPedidoRepository: IRepository<Pedido>
    {
        Task<Pedido?> GetById(int id);
        Task<IEnumerable<Pedido>> GetAll();
        Task<IEnumerable<Pedido>> GetAllBySituacao(int situacaoId);
        void Add(Pedido pedido);
        void Update(Pedido pedido);
        void Remove(Pedido pedido);
    }
}
