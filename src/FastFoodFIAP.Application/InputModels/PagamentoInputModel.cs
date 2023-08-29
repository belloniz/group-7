using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FastFoodFIAP.Application.InputModels
{
    public class PagamentoInputModel
    {        
        [Required(ErrorMessage = "A Situação do pagamento é requerida.")]
        [MinLength(3)]
        [MaxLength(1000)]
        [DisplayName("Situação")]
        public string Situação { get; set; } = "";
    }
}