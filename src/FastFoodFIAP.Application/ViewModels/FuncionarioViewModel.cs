namespace FastFoodFIAP.Application.ViewModels
{
    public class FuncionarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Matricula { get; set; } = "";
        public OcupacaoViewModel? Ocupacao { get; set; }
    }
}