using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IParkingService
    {
        Task<BaseOutput<IList<Parking>>> GetParking();
        Task<BaseOutput<Parking>> GetParkingById(int id);
        Task<BaseOutput<int>> Register(ParkingDto car);
        Task<BaseOutput<bool>> Update(ParkingDto car);
        Task<BaseOutput<bool>> Delete(int id);
    }
}
