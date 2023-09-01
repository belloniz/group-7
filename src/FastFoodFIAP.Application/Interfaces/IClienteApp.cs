
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;
using GenericPack.Messaging;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface IClienteApp : IDisposable
    {

        Task<CommandResult> CadastrarNovoCliente(ClienteInputModel model);
        Task<ClienteViewModel> BuscarClientesPeloId(Guid id);
        Task<ClienteViewModel> BuscarClientePeloCpf(string cpf);
        Task<ClienteViewModel> BuscarClientesPeloEmail(string email);
        Task<List<ClienteViewModel>> BuscarClientesPeloNome(string nome);
        Task<List<ClienteViewModel>> BuscarTodosClientes();
    }
}