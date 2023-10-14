using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<BaseOutput<IList<Vehicle>>> GetVehicle();
        Task<BaseOutput<Vehicle>> GetVehicle(int id);
        Task<BaseOutput<int>> Register(VehicleDto vehicle);
        Task<BaseOutput<bool>> Update(VehicleDto vehicle);
        Task<BaseOutput<bool>> Delete(int id);
    }
}
