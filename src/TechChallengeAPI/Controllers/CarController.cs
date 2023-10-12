using Microsoft.AspNetCore.Mvc;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;

namespace TechChallenge.Api.Controllers
{
    public class CarController : BaseController
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return ModelState.IsValid ? Ok(await _carService.GetCar()) : CustomResponse(ModelState);
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
                return ModelState.IsValid ? Ok(await _carService.GetCar(id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(CarDto car)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _carService.Register(car)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put(CarDto car)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _carService.Update(car)) : CustomResponse(ModelState);
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
                return ModelState.IsValid ? Ok(await _carService.Delete(id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);

            }

        }
    }
}
