using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FastFoodFIAP.Services.Api.Controllers
{
    [ApiController]
    [Route("api/categoria-produto")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CategoriaProdutoController : ApiController
    {
        private readonly ICategoriaProdutoApp _categoriaProdutoApp;

        public CategoriaProdutoController(ICategoriaProdutoApp categoriaProdutoApp)
        {
            _categoriaProdutoApp = categoriaProdutoApp;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista todas as categorias de produtos.",
        Description = "Lista ordenada pelo nome de todas as categorias de produtos"
        )]
        [SwaggerResponse(200, "Success", typeof(List<CategoriaProdutoViewModel>))]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<ActionResult> GetAll()
        {
            var lista = await _categoriaProdutoApp.GetAll();
            return CustomListResponse(lista, lista.Count);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Localiza uma categoria de produtos.",
        Description = "Localiza uma categoria de produtos pelo seu ID."
        )]
        [SwaggerResponse(200, "Success", typeof(CategoriaProdutoViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return CustomResponse(await _categoriaProdutoApp.GetById(id));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Cria uma nova categoria de produtos.",
        Description = "Cria uma nova categoria de produtos."
        )]
        [SwaggerResponse(201, "Success", typeof(CategoriaProdutoViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Post([FromBody] CategoriaProdutoInputModel categoria)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            return CustomCreateResponse(await _categoriaProdutoApp.Add(categoria));
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
        Summary = "Atualiza uma categoria de produtos.",
        Description = "Atualiza uma categoria de produtos."
        )]
        [SwaggerResponse(204, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] CategoriaProdutoInputModel categoria)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            return CustomNoContentResponse(await _categoriaProdutoApp.Update(id, categoria));            
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Exclui uma categoria de produtos.",
        Description = "Exclui uma categoria de produtos."
        )]
        [SwaggerResponse(204, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return CustomNoContentResponse(await _categoriaProdutoApp.Remove(id));
        }
    }
}