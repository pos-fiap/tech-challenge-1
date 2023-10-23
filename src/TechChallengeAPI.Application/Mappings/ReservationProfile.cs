using AutoMapper;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Mappings
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationDto, Reservation>().ReverseMap();
        }
    }
}
