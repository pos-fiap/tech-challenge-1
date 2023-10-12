using AutoMapper;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Mappings
{
<<<<<<<< HEAD:src/TechChallengeAPI.Application/Mappings/CustomerProfile.cs
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Customer>()
========
    public class CostumerProfile : Profile
    {
        public CostumerProfile()
        {
            CreateMap<CostumerDto, Costumer>()
>>>>>>>> 2a00abc54098f34cf5a5a789647fd0c53560a41e:src/TechChallengeAPI.Application/Mappings/CostumerProfile.cs
                .ForPath(prop => prop.Person.Name, map => map.MapFrom(src => src.PersonalInformations.Name))
                .ForPath(prop => prop.Person.Document, map => map.MapFrom(src => src.PersonalInformations.Document))
                .ForPath(prop => prop.Person.Status, map => map.MapFrom(src => src.PersonalInformations.Status))
                .ReverseMap();
        }
    }
}
