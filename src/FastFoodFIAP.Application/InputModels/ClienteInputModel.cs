using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodFIAP.Application.InputModels
{
    public class ClienteInputModel
    {
        [Required]
        [StringLength(100, ErrorMessage="O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = "";

        [EmailAddress]
        public string Email { get; set; } = "";

        [Range(0, 11, ErrorMessage="Um CPF válido deve ter 11 caracteres")]  
        public string Cpf { get; set; } = "";
    }
}