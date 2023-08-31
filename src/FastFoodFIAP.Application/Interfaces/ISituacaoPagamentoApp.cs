using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface ISituacaoPagamentoApp : IDisposable
    {
        Task<List<SituacaoPagamentoViewModel>> GetAll();
    }
}
