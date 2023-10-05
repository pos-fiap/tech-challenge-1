using AutoMapper;
using RCLocacoes.Application.DTOs;
using RCLocacoes.Domain.Entities;

namespace RCLocacoes.Application.Mappings
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
