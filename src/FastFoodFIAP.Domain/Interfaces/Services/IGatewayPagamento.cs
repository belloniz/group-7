using FastFoodFIAP.Domain.Models.PedidoAggregate;

namespace FastFoodFIAP.Domain.Interfaces.Services
{
    public interface IGatewayPagamento
    {
        Task<string> SolicitarQrCodeAsync(Pedido pedido);
    }
}
