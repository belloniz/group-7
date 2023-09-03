namespace FastFoodFIAP.Application.ViewModels
{
    public class FuncionarioViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = "";
        public string Matricula { get; set; } = "";
        public OcupacaoViewModel? Ocupacao { get; set; }


        public FuncionarioViewModel()
        {

        }

        public FuncionarioViewModel(Guid id, string nome, string matricula, OcupacaoViewModel? ocupacao)
        {
            Id = id;
            Nome = nome;
            Matricula = matricula;
            Ocupacao = ocupacao;
        }
    }
}