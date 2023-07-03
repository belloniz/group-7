namespace FastFoodFIAP.Application.InputModels
{
    public class PedidoComboProdutoInputModel
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}