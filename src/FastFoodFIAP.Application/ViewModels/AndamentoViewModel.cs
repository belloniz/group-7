namespace FastFoodFIAP.Application.ViewModels
{
    public class AndamentoViewModel
    {
        public int Id { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public FuncionarioViewModel? Funcionario { get; set; }
        public SituacaoPedidoViewModel? Situacao { get; set; }
        public bool Atual { get; set; }
    }
}
