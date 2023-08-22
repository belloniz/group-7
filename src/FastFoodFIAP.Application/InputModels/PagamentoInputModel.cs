using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FastFoodFIAP.Application.InputModels
{
    public class PagmentoInputModel
    {        
        [Required(ErrorMessage = "O Qr do pagamento é requerido.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Qr")]        
        public string qr { get; set; } = "";

        [Required(ErrorMessage = "A Situação do pagamento é requerida.")]
        [MinLength(3)]
        [MaxLength(1000)]
        [DisplayName("Situação")]
        public string Situação { get; set; } = "";

    }
}