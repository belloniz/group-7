using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodFIAP.Application.InputModels
{
    public class ClienteInputModel
    {
        public string Nome { get; set; } = "";

        public string Email { get; set; } = "";

        public string Cpf { get; set; } = "";
    }
}