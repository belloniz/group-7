using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface ICategoriaProdutoApp : IDisposable
    {
        Task<List<CategoriaProdutoViewModel>> GetAll();
        Task<CategoriaProdutoViewModel> GetById(int id);
        Task<ValidationResult> Add(CategoriaProdutoInputModel model);
        Task<ValidationResult> Update(int id, CategoriaProdutoInputModel model);
        Task<ValidationResult> Remove(int id);
    }
}