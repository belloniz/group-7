using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface IPedidoApp: IDisposable
    {
        Task<List<PedidoViewModel>> GetAllBySituacao(int situacaoId);
        Task<List<PedidoViewModel>> GetAll();
        Task<PedidoViewModel> GetById(Guid id);
        Task<ValidationResult> Add(PedidoInputModel model);
        Task<ValidationResult> Update(Guid id, PedidoInputModel model);
        Task<ValidationResult> Remove(Guid id);
    }
}
