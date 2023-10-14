using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IReservationService
    {
        Task<BaseOutput<bool>> Delete(int id);
        Task<BaseOutput<IList<Reservation>>> GetReservation();
        Task<BaseOutput<Reservation>> GetReservation(int id);
        Task<BaseOutput<int>> Register(ReservationDto reservation);
        Task<BaseOutput<bool>> Update(ReservationDto reservation);
    }
}