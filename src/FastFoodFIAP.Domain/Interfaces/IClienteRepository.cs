
using FastFoodFIAP.Domain.Models;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void CadastrarNovoCliente(Cliente cliente);

        Task<Cliente?> BuscarClientePorCpf(string cpf);
        Task<Cliente?> BuscarClientePorEmail(string email);
        Task<Cliente?> BuscarClientePorNome(string nome);
    }
}