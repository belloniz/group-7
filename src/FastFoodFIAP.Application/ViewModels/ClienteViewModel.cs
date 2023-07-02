namespace FastFoodFIAP.Application.ViewModels
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = "";
        public string Email { get; set; } = "";
        public string Cpf { get; set; } = "";
    }
}