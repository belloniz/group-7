namespace FastFoodFIAP.Application.InputModels
{
    public class PedidoComboInputModel
    {
        public List<PedidoComboProdutoInputModel>? Produtos { get; set; }
        public int Quantidade { get; set; }
    }
}
