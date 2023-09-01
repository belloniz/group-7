
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;
using GenericPack.Messaging;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface IProdutoApp: IDisposable
    {
        Task<List<ProdutoViewModel>> GetAllByCategoria(Guid categoriaId);
        Task<List<ProdutoViewModel>> GetAll();
        Task<ProdutoViewModel> GetById(Guid id);
        Task<CommandResult> Add(ProdutoInputModel model);
        Task<CommandResult> Update(Guid id, ProdutoInputModel model);
        Task<CommandResult> Remove(Guid id);        
    }
}