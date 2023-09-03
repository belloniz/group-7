namespace FastFoodFIAP.Application.ViewModels
{
    public class AndamentoViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public FuncionarioViewModel? Funcionario { get; set; }
        public SituacaoPedidoViewModel? Situacao { get; set; }
        public bool Atual { get; set; }

        public AndamentoViewModel() { 
        }

        public AndamentoViewModel(Guid id, DateTime dataHoraInicio, DateTime? dataHoraFim, FuncionarioViewModel? funcionario, SituacaoPedidoViewModel? situacao, bool atual)
        {
            Id = id;
            DataHoraInicio = dataHoraInicio;
            DataHoraFim = dataHoraFim;
            Funcionario = funcionario;
            Situacao = situacao;
            Atual = atual;
        }

    }
}
