using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FastFoodFIAP.Application.InputModels
{
    public class ProdutoInputModel
    {        
        [Required(ErrorMessage = "O nome do produto é requerido.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]        
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "A descrição do produto é requerida.")]
        [MinLength(3)]
        [MaxLength(1000)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; } = "";

        [Range(0 ,double.MaxValue, ErrorMessage = "O preço do produto deve ser maior que zero.")]
        [DisplayName("Preço")] 
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A categoria do produto é requerida.")]
        public int CategoriaId {get; set;}
        
        public List<string>? ImagensUrl{get; set;} 
    }
}