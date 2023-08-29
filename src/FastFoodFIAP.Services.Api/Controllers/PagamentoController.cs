using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.Services;
using FastFoodFIAP.Application.ViewModels;
using FastFoodFIAP.Domain.Models;

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FastFoodFIAP.Services.Api.Controllers
{
    [ApiController]
    [Route("api/pagamento")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class PagamentoController : ApiController
    {
        private readonly IPagamentoApp _pagamentoApp;

        public PagamentoController(IPagamentoApp pagamentoApp)
        {
            _pagamentoApp = pagamentoApp;
        }

        [HttpPut("{id}/webhook")]
        [SwaggerOperation(
        Summary = "Recebe a confirmação de pagamento aprovado ou pagamento recusado",
        Description = "Recebe a confirmação de pagamento aprovado ou pagamento recusado"
        )]
        [SwaggerResponse(204, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] PagamentoInputModel pagamento)
        {
            try
            {
                if (!ModelState.IsValid)
                    return CustomResponse(ModelState);

                return CustomNoContentResponse(await _pagamentoApp.Update(id, pagamento));
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
            
        }
    }
}
