using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.Authorize;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;

namespace TechChallenge.Api.Controllers
{
    [CustomAuthorization]
    public class ParkingSpotController : BaseController
    {
        private readonly IParkingSpotService _parkingSpotService;

        public ParkingSpotController(IParkingSpotService parkingSpotService)
        {
            _parkingSpotService = parkingSpotService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return ModelState.IsValid ? Ok(await _parkingSpotService.GetParking()) : CustomResponse(ModelState);
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
                return ModelState.IsValid ? Ok(await _parkingSpotService.GetParking(id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ParkingSpotDto parking)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _parkingSpotService.Register(parking)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(ParkingSpotDto parking)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _parkingSpotService.Update(parking)) : CustomResponse(ModelState);
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
                return ModelState.IsValid ? Ok(await _parkingSpotService.Delete(id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);

            }

        }
    }
}
