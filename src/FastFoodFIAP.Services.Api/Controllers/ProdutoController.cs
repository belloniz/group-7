using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FastFoodFIAP.Services.Api.Controllers
{
    [ApiController]
    [Route("api/produto")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ProdutoController : ApiController
    {
        private readonly IProdutoApp _produtoApp;

        public ProdutoController(IProdutoApp produtoApp)
        {
            _produtoApp = produtoApp;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista todos os produtos.",
        Description = "Lista ordenada pelo nome de todos os produtos"
        )]
        [SwaggerResponse(200, "Success", typeof(List<ProdutoViewModel>))]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IEnumerable<ProdutoViewModel>> GetAll()
        {            
            return await _produtoApp.GetAll();                            
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Localiza um produto.",
        Description = "Localiza um produto pelo seu ID."
        )]
        [SwaggerResponse(200, "Success", typeof(ProdutoViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Unexpected error")]
        public  async Task<ProdutoViewModel> GetById([FromRoute] int id)
        {            
            return await _produtoApp.GetById(id);         
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Cria um novo produto.",
        Description = "Cria um novo produto."
        )]
        [SwaggerResponse(201, "Success", typeof(ProdutoViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Post([FromBody] ProdutoInputModel produto)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _produtoApp.Add(produto));
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
        Summary = "Atualiza um produto.",
        Description = "Atualiza um produto."
        )]
        [SwaggerResponse(204, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ProdutoInputModel produto)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _produtoApp.Update(id, produto));
            // try
            // {
            //     if (!ModelState.IsValid)
            //         return BadRequest(ModelState);

            //     if (_categoriaProdutoApp.Update(id, categoria))
            //         return NoContent();
            //     else
            //         return NotFound();
            // }
            // catch (Exception e)
            // {
            //     return Problem("Ocorreu um problema com a requisição - " + e.Message); 
            // }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Exclui um produto.",
        Description = "Exclui um produto."
        )]
        [SwaggerResponse(204, "Success", typeof(ProdutoInputModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return CustomResponse(await _produtoApp.Remove(id));

            // try
            // {
            //     if (!ModelState.IsValid)
            //         return BadRequest(ModelState);

            //     if (_categoriaProdutoApp.Remove(id))
            //         return NoContent();
            //     else
            //         return NotFound();

            // }
            // catch (Exception e)
            // {
            //     return Problem("Ocorreu um problema com a requisição - " + e.Message); 
            // }
        }
    }
}