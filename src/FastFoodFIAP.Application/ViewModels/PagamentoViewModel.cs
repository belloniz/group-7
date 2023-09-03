namespace FastFoodFIAP.Application.ViewModels
{
    public class PagamentoViewModel
    {
        public Guid Id { get; set; }
        public string QrCode { get; set; }
        public decimal Valor { get; set; }
        public SituacaoPagamentoViewModel? Situacao { get; set; }

        public PagamentoViewModel() { 
            QrCode = string.Empty;
        }
        public PagamentoViewModel(Guid id, string qrCode, decimal valor, int situacaoId, string situacao) { 
            Id = id;
            QrCode = qrCode;
            Valor = valor;
            Situacao = new SituacaoPagamentoViewModel(situacaoId, situacao);
        }
    }
}
