using FastFoodFIAP.Domain.Interfaces.Services;

namespace FastFoodFIAP.Infra.MercadoPago
{
    public class MercadoPagoService : IGatewayPagamento
    {
        public string SolicitarQrCode(Guid identificador, string descricao, decimal valor)
        {
            return $"<QR CODE SIMULADO - {descricao}: {valor.ToString("c")}>";
        }
    }
}