using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
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

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista todos os clientes.",
        Description = "Lista ordenada pelo nome de todos os clientes"
        )]
        [SwaggerResponse(200, "Success", typeof(List<ClienteViewModel>))]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<ActionResult> BuscarTodosClientes()
        {
            var lista = await _clienteApp.BuscarTodosClientes();
            return CustomListResponse(lista, lista.Count);
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

        [HttpGet("/busca/cpf/{cpf}")]
        [SwaggerOperation(
        Summary = "Localiza um cliente pelo seu CPF",
        Description = "Localiza um cliente pelo seu CPF."
        )]
        [SwaggerResponse(200, "Success", typeof(ClienteViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> BuscarClientePeloCpf([FromRoute] string cpf)
        {
            return CustomResponse(await _clienteApp.BuscarClientePeloCpf(cpf));
        }

        [HttpGet("/busca/email/{email}")]
        [SwaggerOperation(
        Summary = "Localiza um cliente pelo seu endereço de email.",
        Description = "Localiza um cliente pelo seu endereço de email."
        )]
        [SwaggerResponse(200, "Success", typeof(ClienteViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> BuscarClientesPeloEmail([FromRoute] string email)
        {
            return CustomResponse(await _clienteApp.BuscarClientesPeloEmail(email));
        }

        [HttpGet("/busca/nome/{nome}")]
        [SwaggerOperation(
        Summary = "Localiza clientes pelo nome.",
        Description = "Localiza clientes pelo nome."
        )]
        [SwaggerResponse(200, "Success", typeof(ClienteViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> BuscarClientesPeloNome([FromRoute] string nome)
        {
            var lista = await _clienteApp.BuscarClientesPeloNome(nome);
            return CustomListResponse(lista, lista.Count);
        }
    }
}