namespace FastFoodFIAP.Application.ViewModels
{
    public class PedidoViewModel
    {
            public int Id { get; set; }
            public int ClienteId {get; set;}
            public List<PedidoItemViewModel>? Itens {get; set;}
    }
}
