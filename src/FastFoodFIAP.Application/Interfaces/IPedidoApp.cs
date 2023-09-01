using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;
using GenericPack.Messaging;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface IPedidoApp: IDisposable
    {
        Task<List<PedidoViewModel>> GetAllBySituacao(int situacaoId);
        Task<List<PedidoViewModel>> GetAll();
        Task<List<PedidoViewModel>> GetAllAtivos();
        Task<PedidoViewModel> GetById(Guid id);
        Task<CommandResult> Add(PedidoInputModel model);
        Task<CommandResult> Update(Guid id, PedidoInputModel model);
        Task<CommandResult> Remove(Guid id);
        bool PagamentoAprovado(Guid id);
    }
}
