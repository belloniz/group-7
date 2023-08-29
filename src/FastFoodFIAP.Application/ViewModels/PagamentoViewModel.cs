namespace FastFoodFIAP.Application.ViewModels
{
    public class PagamentoViewModel
    {
        public Guid Id { get; set; }
        public required String QrCode { get; set; }
        public decimal Valor { get; set; }
        public int SituacaoId { get; private set; }
    }
}
