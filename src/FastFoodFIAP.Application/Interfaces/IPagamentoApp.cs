using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;
using GenericPack.Messaging;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface IPagamentoApp: IDisposable
    {   
        Task<CommandResult> Update(PagamentoInputModel model);
    }
}
