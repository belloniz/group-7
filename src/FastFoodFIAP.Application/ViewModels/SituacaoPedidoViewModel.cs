using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodFIAP.Application.ViewModels
{
    public class SituacaoPedidoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";

        public SituacaoPedidoViewModel() { }

        public SituacaoPedidoViewModel(int id, string nome) { 
            Id = id;
            Nome = nome;
        }
    }
}
