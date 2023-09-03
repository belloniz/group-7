using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodFIAP.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = "";
        public string Descricao { get; set; } = "";
        public decimal Preco { get; set; }
        public CategoriaProdutoViewModel? Categoria {get; set;}
        public List<ImagemViewModel>? Imagens {get; set;}

        public ProdutoViewModel() { }

        public ProdutoViewModel(Guid id, string nome, string descricao, decimal preco, CategoriaProdutoViewModel? categoria) { 
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Categoria = categoria;
        }

    }
}