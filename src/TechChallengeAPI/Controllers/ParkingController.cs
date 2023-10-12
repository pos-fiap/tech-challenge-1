using Microsoft.AspNetCore.Mvc;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;

namespace TechChallenge.Api.Controllers
{
    public class ParkingController : BaseController
    {
        private readonly IParkingService _parkingService;

        public ParkingController(IParkingService parkingService)
        {
            _parkingService = parkingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return ModelState.IsValid ? Ok(await _parkingService.GetParking()) : CustomResponse(ModelState);
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
                return ModelState.IsValid ? Ok(await _parkingService.GetParking(id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(ParkingDto parking)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _parkingService.Register(parking)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put(ParkingDto parking)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _parkingService.Update(parking)) : CustomResponse(ModelState);
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
                return ModelState.IsValid ? Ok(await _parkingService.Delete(id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);

            }

        }
    }
}
