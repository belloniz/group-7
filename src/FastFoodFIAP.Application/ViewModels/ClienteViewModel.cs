namespace FastFoodFIAP.Application.ViewModels
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; } 
        public string? Email { get; set; } 
        public string? Cpf { get; set; } 

        public ClienteViewModel() { 
        
        }

        public ClienteViewModel(Guid id, string? nome, string? email, string? cpf) { 
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }
    }
}