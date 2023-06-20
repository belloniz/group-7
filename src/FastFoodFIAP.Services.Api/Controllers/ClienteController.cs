using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.Services;
using FastFoodFIAP.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FastFoodFIAP.Services.Api.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ClienteController : ApiController
    {
        private readonly IClienteApp _clienteApp;

        public ClienteController(IClienteApp clienteApp)
        {
            _clienteApp = clienteApp;
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Cadastra um novo cliente.",
        Description = "Cadastra um novo cliente."
        )]
        [SwaggerResponse(201, "Success", typeof(ClienteInputModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> CadastrarNovoCliente([FromBody] ClienteInputModel cliente)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);
                
            return CustomCreateResponse(await _clienteApp.CadastrarNovoCliente(cliente));
        }

        [HttpGet("{cpf}")]
        [SwaggerOperation(
        Summary = "Localiza um cliente.",
        Description = "Localiza um cliente pelo seu CPF."
        )]
        [SwaggerResponse(200, "Success", typeof(ClienteViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> BuscarClientePorCpf([FromRoute] string cpf)
        {
            return CustomResponse(await _clienteApp.BuscarClientePorCpf(cpf));
        }
    }
}