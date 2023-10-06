using AutoMapper;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Mappings
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
