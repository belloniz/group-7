namespace FastFoodFIAP.Application.ViewModels
{
    public class OcupacaoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = "";     
        
        public OcupacaoViewModel() { }

        public OcupacaoViewModel(Guid id, string nome) { 
            Id = id;
            Nome = nome;
        }
    }
}