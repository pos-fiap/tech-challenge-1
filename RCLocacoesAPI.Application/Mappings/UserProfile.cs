using AutoMapper;
using RCLocacoes.Application.DTOs;
using RCLocacoes.Domain.Entities;

namespace RCLocacoes.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(prop => prop.Password, map => map.MapFrom(src => src.PasswordHash)).ReverseMap();
        }
    }
}
