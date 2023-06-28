using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.Services;
using FastFoodFIAP.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FastFoodFIAP.Services.Api.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class PedidoController: ApiController
    {
        private readonly IPedidoApp _pedidoApp;
        private readonly IAndamentoApp _andamentoApp;

        public PedidoController(IPedidoApp pedidoApp, IAndamentoApp andamentoApp)
        {
            _pedidoApp = pedidoApp;
            _andamentoApp = andamentoApp;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista todos os pedidos.",
        Description = "Lista ordenada pela data de todos os pedidos"
        )]
        [SwaggerResponse(200, "Success", typeof(List<PedidoViewModel>))]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<ActionResult> GetAll()
        {
            var lista = await _pedidoApp.GetAll();
            return CustomListResponse(lista, lista.Count);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Localiza um pedido.",
        Description = "Localiza um pedido pelo seu ID."
        )]
        [SwaggerResponse(200, "Success", typeof(PedidoViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return CustomResponse(await _pedidoApp.GetById(id));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Cria um novo pedido.",
        Description = "Cria um novo pedido."
        )]
        [SwaggerResponse(201, "Success", typeof(PedidoInputModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Post([FromBody] PedidoInputModel pedidoInputModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            return CustomCreateResponse(await _pedidoApp.Add(pedidoInputModel));
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
        Summary = "Atualiza um pedido.",
        Description = "Atualiza um pedido."
        )]
        [SwaggerResponse(204, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PedidoInputModel pedido)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            return CustomNoContentResponse( await _pedidoApp.Update(id, pedido));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Exclui um pedido.",
        Description = "Exclui um pedido."
        )]
        [SwaggerResponse(204, "Success", typeof(PedidoInputModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return CustomNoContentResponse(await _pedidoApp.Remove(id));
        }

        [HttpPost("{id}/andamento")]
        [SwaggerOperation(
        Summary = "Criar um novo andamento para o pedido.",
        Description = "Criar um novo andamento para o pedido."
        )]
        [SwaggerResponse(201, "Success", typeof(List<AndamentoViewModel>))]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<ActionResult> CriarAndamento([FromRoute] int id, [FromBody] AndamentoInputModel andamento)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);
            
            return CustomCreateResponse(await _andamentoApp.Add(andamento));
        }        
    }
}
