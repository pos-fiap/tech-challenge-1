using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IParkingSpotService
    {
        Task<BaseOutput<IList<ParkingSpot>>> Get();
        Task<BaseOutput<ParkingSpot>> Get(int id);
        Task<BaseOutput<int>> Create(ParkingSpotDto vehicle);
        Task<BaseOutput<bool>> Update(ParkingSpotDto vehicle);
        Task<BaseOutput<bool>> Delete(int id);
        Task<BaseOutput<IList<ParkingSpot>>> GetAllFreeParkingSpots();
    }
}
