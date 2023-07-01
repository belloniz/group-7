namespace FastFoodFIAP.Application.ViewModels
{
    public class PagamentoViewModel
    {
        public int Id { get; set; }
        public required String QrCode { get; set; }
        public decimal Valor { get; set; }      
    }
}