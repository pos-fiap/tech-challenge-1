using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IClientService
    {
        Task<BaseOutput<IList<Client>>> GetClient();
        Task<BaseOutput<Client>> GetIdClientById(int id);
        Task<BaseOutput<int>> Register(ClientDto car);
        Task<BaseOutput<bool>> Update(ClientDto car);
        Task<BaseOutput<bool>> Delete(int id);
    }
}
