using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TechChallenge.Application.BaseResponse;

namespace TechChallenge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult InternalErrorResponse(Exception ex)
        {
            BaseOutput<string> response = new();
            response.AddError(ex.Message);
            return StatusCode(500, response);
        }

        protected IActionResult BadRequestResponse(string msg)
        {
            BaseOutput<string> response = new();
            response.AddError(msg);
            return StatusCode(400, response);
        }

        protected IActionResult ValidatorErrorResponse(List<ValidationFailure> errors)
        {
            BaseOutput<string> response = new();
            errors.ForEach(error =>
            {
                response.AddError(error.ErrorMessage);
            });
            return StatusCode(400, response);
        }

        protected ActionResult CustomResponse<TParam>(BaseOutput<TParam> baseResponse)
        {
            if (IsOperationInvalid(baseResponse.Errors))
            {
                return BadRequest(baseResponse);
            }
            return Ok(baseResponse);
        }


        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            BaseOutput<bool> response = new()
            {
                IsSuccessful = false
            };

            foreach (KeyValuePair<string, ModelStateEntry> state in modelState)
            {
                foreach (ModelError error in state.Value.Errors)
                {
                    response.AddError(error.ErrorMessage);
                }
            }

            return BadRequest(response);
        }


        protected bool IsOperationInvalid(IList<string> errors)
        {
            return errors.Any();
        }
    }
}