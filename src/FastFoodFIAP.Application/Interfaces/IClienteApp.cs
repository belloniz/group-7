
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface IClienteApp : IDisposable
    {
        Task<ValidationResult> CadastrarNovoCliente(ClienteInputModel model);
        Task<ClienteViewModel> BuscarClientePorCpf(string cpf);
        Task<ClienteViewModel> BuscarClientePorEmail(string email);
        Task<ClienteViewModel> BuscarClientePorNome(string nome);
    }
}