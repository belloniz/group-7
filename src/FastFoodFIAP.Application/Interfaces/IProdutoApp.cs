
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface IProdutoApp: IDisposable
    {
        Task<List<ProdutoViewModel>> GetAllByCategoria(Guid categoriaId);
        Task<List<ProdutoViewModel>> GetAll();
        Task<ProdutoViewModel> GetById(Guid id);
        Task<ValidationResult> Add(ProdutoInputModel model);
        Task<ValidationResult> Update(Guid id, ProdutoInputModel model);
        Task<ValidationResult> Remove(Guid id);        
    }
}