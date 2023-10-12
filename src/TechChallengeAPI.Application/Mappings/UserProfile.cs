using AutoMapper;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(prop => prop.Id, map => map.MapFrom(src => src.Id))
                .ForMember(prop => prop.PasswordHash, map => map.MapFrom(src => src.Password))
                .ForPath(prop => prop.Person.Id, map => map.MapFrom(src => src.PersonalInformations.Id))
                .ForPath(prop => prop.Person.Name, map => map.MapFrom(src => src.PersonalInformations.Name))
                .ForPath(prop => prop.Person.Document, map => map.MapFrom(src => src.PersonalInformations.Document))
                .ForPath(prop => prop.Person.Status, map => map.MapFrom(src => src.PersonalInformations.Status))
                .ReverseMap();
        }
    }
}
