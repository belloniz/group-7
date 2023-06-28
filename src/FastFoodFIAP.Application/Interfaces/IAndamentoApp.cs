using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface IAndamentoApp
    {
        Task<ValidationResult> Add(AndamentoInputModel model);
        Task<ValidationResult> Update(int id, AndamentoInputModel model);
    }
}
