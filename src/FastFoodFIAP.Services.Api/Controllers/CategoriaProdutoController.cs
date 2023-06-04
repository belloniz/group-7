using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FastFoodFIAP.Services.Api.Controllers
{
    [ApiController]
    [Route("api/categoria-produto")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CategoriaProdutoController : ControllerBase
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
        public ActionResult GetAll()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var lista = _categoriaProdutoApp.GetAll();

                if (lista.Count==0)
                    return NoContent();                            

                return Ok(lista);                
            }
            catch (System.Exception e)
            {
                return Problem("Ocorreu um problema com a requisição - " + e.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Localiza uma categoria de produtos.",
        Description = "Localiza uma categoria de produtos pelo seu ID."
        )]
        [SwaggerResponse(200, "The product was found", typeof(CategoriaProdutoViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Unexpected error")]
        public ActionResult GetById([FromRoute] int id)
        {
            try
            {                

                if (!ModelState.IsValid)
                   return  BadRequest();                
                
                var categoria = _categoriaProdutoApp.GetById(id);

                if (categoria == null)
                    return  NotFound($"A categoria com o ID = {id} não existe.");
                    
                return Ok(categoria);
            }
            catch (Exception e)
            {               
                return Problem("Ocorreu um problema com a requisição - " + e.Message);                               
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
        public ActionResult Post([FromBody] CategoriaProdutoInputModel categoria)
        {
            try
            {                
                return StatusCode(StatusCodes.Status201Created,_categoriaProdutoApp.Add(categoria));
            }
            catch (Exception e)
            {
                return Problem("Ocorreu um problema com a requisição - " + e.Message); 
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
        public ActionResult Put([FromRoute] int id, [FromBody] CategoriaProdutoInputModel categoria)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (_categoriaProdutoApp.Update(id, categoria))
                    return NoContent();
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return Problem("Ocorreu um problema com a requisição - " + e.Message); 
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Exclui uma categoria de produtos.",
        Description = "Exclui uma categoria de produtos."
        )]
        [SwaggerResponse(204, "Success", typeof(CategoriaProdutoViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Unexpected error")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (_categoriaProdutoApp.Remove(id))
                    return NoContent();
                else
                    return NotFound();

            }
            catch (Exception e)
            {
                return Problem("Ocorreu um problema com a requisição - " + e.Message); 
            }
        }

    }
}