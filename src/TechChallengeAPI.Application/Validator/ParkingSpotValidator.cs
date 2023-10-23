using FluentValidation;
using TechChallenge.Application.DTOs;

namespace TechChallenge.Application.Validator
{
    public class ParkingSpotValidator : AbstractValidator<ParkingSpotDto>
    {
        public ParkingSpotValidator()
        {
            RuleFor(p => p.Description).NotNull().WithMessage("Description is a required field");
            RuleFor(p => p.Status).NotNull().WithMessage("Status is a required field");
        }
    }
}