namespace FastFoodFIAP.Application.ViewModels
{
    public class CategoriaProdutoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = "";

        public CategoriaProdutoViewModel() { }

        public CategoriaProdutoViewModel(Guid id, string nome) { 
            Id = id;
            Nome = nome;
        }
    }
}