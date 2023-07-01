namespace FastFoodFIAP.Application.InputModels
{
    public class PedidoInputModel
    {
        public int ClienteId {get; set;}
        public List<PedidoComboInputModel>? Combos {get; set;}
    }
}
