using FastFoodFIAP.Domain.Models;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface IPagamentoRepository: IRepository<Pagamento>
    {
        Task<Pagamento?> GetById(Guid id);
        Task<IEnumerable<Pagamento>> GetAll();
        void Add(Pagamento pagamento);
        void Update(Pagamento pagamento);
        void Remove(Pagamento pagamento);
    }
}
