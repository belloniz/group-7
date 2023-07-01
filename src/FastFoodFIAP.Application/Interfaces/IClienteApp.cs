
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface IClienteApp : IDisposable
    {

        Task<ValidationResult> CadastrarNovoCliente(ClienteInputModel model);
        Task<ClienteViewModel> BuscarClientePeloCpf(string cpf);
        Task<ClienteViewModel> BuscarClientesPeloEmail(string email);
        Task<List<ClienteViewModel>> BuscarClientesPeloNome(string nome);
        Task<List<ClienteViewModel>> BuscarTodosClientes();
    }
}