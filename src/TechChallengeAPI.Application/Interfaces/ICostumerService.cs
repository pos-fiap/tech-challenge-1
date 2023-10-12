using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface ICostumerService
    {
        Task<BaseOutput<IList<Costumer>>> GetCostumer();
        Task<BaseOutput<Costumer>> GetIdCostumer(int id);
        Task<BaseOutput<int>> Register(CostumerDto car);
        Task<BaseOutput<bool>> Update(CostumerDto car);
        Task<BaseOutput<bool>> Delete(int id);
    }
}
