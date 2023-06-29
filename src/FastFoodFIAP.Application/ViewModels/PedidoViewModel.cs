namespace FastFoodFIAP.Application.ViewModels
{
    public class PedidoViewModel
    {
            public int Id { get; set; }
            public ClienteViewModel Cliente {get; set;}
            public List<PedidoComboViewModel>? Combos {get; set;}
            //public AndamentoViewModel? Situacao { get; set;}
    }
}
