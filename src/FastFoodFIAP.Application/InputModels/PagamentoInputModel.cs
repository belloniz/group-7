using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FastFoodFIAP.Application.InputModels
{
    public class PagamentoInputModel
    {        
        [Required(ErrorMessage = "A Situação do pagamento é requerida.")] // Validar que é 1 (aprovado) ou 2 (recusado)
        public int SituacaoId { get; set; }

        [Required(ErrorMessage = "O id do pagamento é requerido.")] 
        public Guid Id { get; set; }
    }
}
