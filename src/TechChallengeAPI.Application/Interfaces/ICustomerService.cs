using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<BaseOutput<IList<Customer>>> Get();
        Task<BaseOutput<Customer>> GetById(int id);
        Task<BaseOutput<int>> Create(CustomerDto vehicle);
        Task<BaseOutput<bool>> Update(CustomerDto vehicle);
        Task<bool> VerifyUser(int Id);
    }
}
