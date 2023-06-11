using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands.Validations
{
    public class CategoriaProdutoValidationsUpdate : CategoriaProdutoValidations<CategoriaProdutoUpdateCommand>
    {
        public CategoriaProdutoValidationsUpdate()
        {
            ValidaId();
            ValidaNome();
        }
    }
}