using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IValetService
    {
        Task<BaseOutput<IList<Valet>>> GetValet();
        Task<BaseOutput<Valet>> GetValet(int id);
        Task<BaseOutput<int>> Register(ValetDto vehicle);
        Task<BaseOutput<bool>> Update(ValetDto vehicle);
        Task<BaseOutput<bool>> Delete(int id);
    }
}
