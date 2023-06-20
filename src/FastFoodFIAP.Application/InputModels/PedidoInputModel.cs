namespace FastFoodFIAP.Application.InputModels
{
    public class PedidoInputModel
    {
        public int ClienteId {get; set;}
        public List<PedidoItemInputModel>? Itens {get; set;}
    }
}
