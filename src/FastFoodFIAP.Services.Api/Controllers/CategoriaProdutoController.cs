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
            try
            {
                var lista = await _categoriaProdutoApp.GetAll();
                return CustomListResponse(lista, lista.Count);
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }            
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
            try
            {
                return CustomResponse(await _categoriaProdutoApp.GetById(id));
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
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
            try
            {
                if (!ModelState.IsValid)
                    return CustomResponse(ModelState);

                var result = await _categoriaProdutoApp.Add(categoria);
                if (result.Id != null)
                    return CustomResponse(await _categoriaProdutoApp.GetById((Guid)result.Id));
                else
                    return CustomCreateResponse(result);

                //return CustomCreateResponse(await _categoriaProdutoApp.Add(categoria));
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
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
            try
            {
                if (!ModelState.IsValid)
                    return CustomResponse(ModelState);

                return CustomNoContentResponse(await _categoriaProdutoApp.Update(id, categoria));
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
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
            try
            {
                return CustomNoContentResponse(await _categoriaProdutoApp.Remove(id));
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
            
        }
    }
}