using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface ICustomerVehicleService
    {
        Task<BaseOutput<IList<CustomerVehicle>>> GetCustomerVehicle();
        Task<BaseOutput<CustomerVehicle>> GetCustomerVehicle(int id);
        Task<BaseOutput<int>> Register(CustomerVehicleDto customerVehicle);
        Task<BaseOutput<bool>> Update(CustomerVehicleDto customerVehicle);
        Task<BaseOutput<bool>> Delete(int id);
    }
}
