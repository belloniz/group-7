using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using GenericPack.Messaging;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface IAndamentoApp
    {
        Task<CommandResult> Add(AndamentoInputModel model);
        Task<CommandResult> Update(Guid id, AndamentoInputModel model);
    }
}
