using System.ComponentModel.DataAnnotations;

namespace FastFoodFIAP.Application.InputModels
{
    public class ClienteInputModel
    {
        //[StringLength(100, ErrorMessage="O nome deve ter no máximo 100 caracteres")]        
        public string? Nome { get; set; }

        //[EmailAddress(ErrorMessage = "E-mail com formato inválido.")]
        public string? Email { get; set; }

        //[Range(0, 11, ErrorMessage="Um CPF válido deve ter 11 caracteres")]  
        public string? Cpf { get; set; }
    }
}