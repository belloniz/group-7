using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface ISituacaoPedidoApp : IDisposable
    {
        Task<List<SituacaoPedidoViewModel>> GetAll();
    }
}