using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IParkingSpotService
    {
        Task<BaseOutput<IList<ParkingSpot>>> GetParking();
        Task<BaseOutput<ParkingSpot>> GetParking(int id);
        Task<BaseOutput<int>> Register(ParkingSpotDto vehicle);
        Task<BaseOutput<bool>> Update(ParkingSpotDto vehicle);
        Task<BaseOutput<bool>> Delete(int id);
    }
}
