using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.Authorize;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;

namespace TechChallenge.Api.Controllers
{
    [CustomAuthorization]
    public class ValetController : BaseController
    {
        private readonly IValetService _valetService;

        public ValetController(IValetService valetService)
        {
            _valetService = valetService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return ModelState.IsValid ? Ok(await _valetService.GetValet()) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _valetService.GetValet(id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(ValetDto valet)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _valetService.Register(valet)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put(ValetDto valet)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _valetService.Update(valet)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _valetService.Delete(id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);

            }
        }
    }
}
