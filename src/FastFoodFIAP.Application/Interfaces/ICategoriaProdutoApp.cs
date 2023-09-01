using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;
using GenericPack.Messaging;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface ICategoriaProdutoApp : IDisposable
    {
        Task<List<CategoriaProdutoViewModel>> GetAll();
        Task<CategoriaProdutoViewModel> GetById(Guid id);
        Task<CommandResult> Add(CategoriaProdutoInputModel model);
        Task<CommandResult> Update(Guid id, CategoriaProdutoInputModel model);
        Task<CommandResult> Remove(Guid id);
    }
}