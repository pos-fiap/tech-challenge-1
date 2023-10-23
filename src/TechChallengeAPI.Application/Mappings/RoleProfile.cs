using AutoMapper;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>()
                .ForMember(prop => prop.Description, map => map.MapFrom(src => src.Description)).ReverseMap();

            CreateMap<Role, RoleUpdateDto>()
               .ForMember(prop => prop.Description, map => map.MapFrom(src => src.Description))
               .ForMember(prop => prop.Id, map => map.MapFrom(src => src.Id))
               .ReverseMap();
        }
    }
}
