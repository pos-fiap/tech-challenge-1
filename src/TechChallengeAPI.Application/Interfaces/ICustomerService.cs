using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<BaseOutput<IList<Customer>>> GetCustomer();
        Task<BaseOutput<Customer>> GetIdCustomerById(int id);
        Task<BaseOutput<int>> Register(CustomerDto car);
        Task<BaseOutput<bool>> Update(CustomerDto car);
        Task<BaseOutput<bool>> Delete(int id);
    }
}
