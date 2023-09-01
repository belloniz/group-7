using FluentValidation.Results;
using GenericPack.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FastFoodFIAP.Services.Api.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private readonly ICollection<string> _errors = new List<string>();

        protected ActionResult CustomResponse(object? result = null)
        {
            if (IsOperationValid())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", _errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(CommandResult commandResult)
        {
            foreach (var error in commandResult.ValidationResult.Errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomCreateResponse(object? result = null)
        {
            if (IsOperationValid())
            {
                return StatusCode(StatusCodes.Status201Created, result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", _errors.ToArray() }
            }));
        }

        protected ActionResult CustomCreateResponse(CommandResult commandResult)
        {
            foreach (var error in commandResult.ValidationResult.Errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomCreateResponse();
        }

        protected ActionResult CustomNoContentResponse(object? result = null)
        {
            if (IsOperationValid())
            {
                return NoContent();
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", _errors.ToArray() }
            }));
        }

        protected ActionResult CustomNoContentResponse(CommandResult commandResult)
        {
            foreach (var error in commandResult.ValidationResult.Errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomNoContentResponse();
        }

        protected ActionResult CustomListResponse(object result, int count)
        {
            if (IsOperationValid())
            {
                return count > 0 ? Ok(result): NoContent();
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", _errors.ToArray() }
            }));
        }

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(string erro)
        {
            _errors.Add(erro);
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }
    }
}