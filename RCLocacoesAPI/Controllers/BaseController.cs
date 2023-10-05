using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RCLocacoes.Application.BaseResponse;

namespace RCLocacoes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult InternalErrorResponse(Exception ex)
        {
            var response = new BaseOutput<string>();
            response.AddError(ex.Message);
            return StatusCode(500, response);
        }

        protected IActionResult BadRequestResponse(string msg)
        {
            var response = new BaseOutput<string>();
            response.AddError(msg);
            return StatusCode(400, response);
        }

        protected IActionResult ValidatorErrorResponse(List<ValidationFailure> errors)
        {
            var response = new BaseOutput<string>();
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
            var response = new BaseOutput<bool>();

            response.IsSuccessful = false;

            foreach (var state in modelState)
            {
                foreach (var error in state.Value.Errors)
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