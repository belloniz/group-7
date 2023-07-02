using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.Services;
using FastFoodFIAP.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FastFoodFIAP.Services.Api.Controllers
{
    [ApiController]
    [Route("api/funcionario")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class FuncionarioController: ApiController
    {
        private readonly IFuncionarioApp _funcionarioApp;        

        public FuncionarioController(IFuncionarioApp funcionarioApp)
        {
            _funcionarioApp = funcionarioApp;            
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista todos os funcionários.",
        Description = "Lista de todos os funcionários ordenada por nome."
        )]
        [SwaggerResponse(200, "Success", typeof(List<FuncionarioViewModel>))]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<ActionResult> GetAll()
        {
            var lista = await _funcionarioApp.GetAll();
            return CustomListResponse(lista, lista.Count);
        }
    }
}
