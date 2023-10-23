using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IValetService
    {
        Task<BaseOutput<IList<Valet>>> Get();
        Task<BaseOutput<Valet>> Get(int id);
        Task<BaseOutput<int>> Create(ValetDto vehicle);
        Task<BaseOutput<bool>> Update(ValetDto vehicle);
        Task<BaseOutput<bool>> Delete(int id);
    }
}
