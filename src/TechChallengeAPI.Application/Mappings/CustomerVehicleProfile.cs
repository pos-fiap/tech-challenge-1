using AutoMapper;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Mappings
{
    public class CustomerVehicleProfile : Profile
    {
        public CustomerVehicleProfile()
        {
            CreateMap<CustomerVehicleDto, CustomerVehicle>()
                .ReverseMap();
        }
    }
}
