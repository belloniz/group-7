using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface IPagamentoApp: IDisposable
    {   
        Task<ValidationResult> Update(Guid id, PagamentoInputModel model);
    }
}
