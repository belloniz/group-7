using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodFIAP.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Descricao { get; set; } = "";
        public decimal Preco { get; set; }
        public CategoriaProdutoViewModel? Categoria {get; set;}
        public List<ImagemViewModel>? Imagens {get; set;}
    }
}