
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface IClienteApp : IDisposable
    {
        Task<ClienteViewModel> BuscarClientePorCpf(string cpf);
        Task<ValidationResult> CadastrarNovoCliente(ClienteInputModel model);
    }
}