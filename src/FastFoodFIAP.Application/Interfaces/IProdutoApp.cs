
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface IProdutoApp: IDisposable
    {
        Task<List<ProdutoViewModel>> GetAllByCategoria(int categoriaId);
        Task<List<ProdutoViewModel>> GetAll();
        Task<ProdutoViewModel> GetById(int id);
        Task<ValidationResult> Add(ProdutoInputModel model);
        Task<ValidationResult> Update(int id, ProdutoInputModel model);
        Task<ValidationResult> Remove(int id);        
    }
}