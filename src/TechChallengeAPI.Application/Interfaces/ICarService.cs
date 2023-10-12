using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface ICarService
    {
        Task<BaseOutput<IList<Car>>> GetCar();
        Task<BaseOutput<Car>> GetCar(int id);
        Task<BaseOutput<int>> Register(CarDto car);
        Task<BaseOutput<bool>> Update(CarDto car);
        Task<BaseOutput<bool>> Delete(int id);
    }
}
