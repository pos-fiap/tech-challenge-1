using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface ICustomerVehicleService
    {
        Task<BaseOutput<IList<CustomerVehicle>>> Get();
        Task<BaseOutput<CustomerVehicle>> Get(int id);
        Task<BaseOutput<int>> Create(CustomerVehicleDto customerVehicle);
        Task<BaseOutput<bool>> Update(CustomerVehicleDto customerVehicle);
        Task<BaseOutput<bool>> Delete(int id);
    }
}
