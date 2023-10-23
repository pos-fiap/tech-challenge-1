using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<BaseOutput<IList<Vehicle>>> Get();
        Task<BaseOutput<Vehicle>> Get(int id);
        Task<BaseOutput<int>> Create(VehicleDto vehicle);
        Task<BaseOutput<bool>> Update(VehicleDto vehicle);
        Task<BaseOutput<bool>> Delete(int id);
    }
}
