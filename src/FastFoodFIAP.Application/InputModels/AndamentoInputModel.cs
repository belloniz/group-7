using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodFIAP.Application.InputModels
{
    public class AndamentoInputModel
    {
        public Guid pedidoId { get; set; }
        public Guid FuncionarioId { get; set; }
        public int SituacaoId { get; set; }
    }
}
