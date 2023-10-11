using AutoMapper;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Mappings
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientDto, Client>()
                .ForPath(prop => prop.Person.Name, map => map.MapFrom(src => src.PersonalInformations.Name))
                .ForPath(prop => prop.Person.Document, map => map.MapFrom(src => src.PersonalInformations.Document))
                .ForPath(prop => prop.Person.Status, map => map.MapFrom(src => src.PersonalInformations.Status))
                .ReverseMap();
        }
    }
}
