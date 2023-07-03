namespace FastFoodFIAP.Domain.Interfaces.Services
{
    public interface IGatewayPagamento
    {
        string SolicitarQrCode(Guid identificador, string descricao, decimal valor);
    }
}
