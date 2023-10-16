using AutoMapper;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Mappings
{
    public class ParkingSpotProfile : Profile
    {
        public ParkingSpotProfile()
        {
            CreateMap<ParkingSpotDto, ParkingSpot>().ReverseMap();
        }
    }
}
