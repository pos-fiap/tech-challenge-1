using RCLocacoes.Application.BaseResponse;
using RCLocacoes.Application.DTOs;
using RCLocacoes.Domain.Entities;

namespace RCLocacoes.Application.Interfaces
{
    public interface IAddressService
    {
        Task<BaseOutput<List<Address>>> GetAll();
        Task<BaseOutput<int>> RegisterAddress(AddressDto addressDto);
        Task<bool> VerifyAddress(int Id);
        Task<BaseOutput<bool>> DeleteAddress(int Id);
    }
}