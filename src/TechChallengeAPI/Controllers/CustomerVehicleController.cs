using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.Authorize;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;

namespace TechChallenge.Api.Controllers
{
    [CustomAuthorization]
    public class CustomerVehicleController : BaseController
    {
        private readonly ICustomerVehicleService _customerVehicleService;

        public CustomerVehicleController(ICustomerVehicleService customerVehicleService)
        {
            _customerVehicleService = customerVehicleService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return ModelState.IsValid ? Ok(await _customerVehicleService.Get()) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _customerVehicleService.Get(id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(CustomerVehicleDto customerVehicle)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _customerVehicleService.Create(customerVehicle)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put(CustomerVehicleDto customerVehicle)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _customerVehicleService.Update(customerVehicle)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _customerVehicleService.Delete(id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);

            }

        }
    }
}
