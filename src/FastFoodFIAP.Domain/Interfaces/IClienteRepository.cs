
using FastFoodFIAP.Domain.Models;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void CadastrarNovoCliente(Cliente cliente);
        Task<Cliente?> BuscarClientePeloId(Guid id);
        Task<Cliente?> BuscarClientePeloCpf(string cpf);
        Task<Cliente?> BuscarClientesPeloEmail(string email);
        Task<IEnumerable<Cliente>> BuscarClientesPeloNome(string nome);
        Task<IEnumerable<Cliente>> BuscarTodosClientes();
    }
}
