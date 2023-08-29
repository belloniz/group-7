using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FastFoodFIAP.Application.InputModels
{
    public class PagamentoInputModel
    {        
        [Required(ErrorMessage = "A Situação do pagamento é requerida.")] // Validar que é 1 (aprovado) ou 2 (recusado)
        public int SituaçãoId { get; set; }
    }
}