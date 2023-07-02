namespace FastFoodFIAP.Application.InputModels
{
    public class PedidoInputModel
    {
        public Guid? ClienteId {get; set;}
        public List<PedidoComboInputModel>? Combos {get; set;}
    }
}
