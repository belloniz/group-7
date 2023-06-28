using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface IPedidoApp: IDisposable
    {        
        Task<List<PedidoViewModel>> GetAll();
        Task<PedidoViewModel> GetById(int id);
        Task<ValidationResult> Add(PedidoInputModel model);
        Task<ValidationResult> Update(int id, PedidoInputModel model);
        Task<ValidationResult> Remove(int id);
    }
}
