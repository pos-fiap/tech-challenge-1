using FluentValidation;
using TechChallenge.Application.DTOs;

namespace TechChallenge.Application.Validator
{
    public class VehicleValidator : AbstractValidator<VehicleDto>
    {
        public VehicleValidator()
        {
            RuleFor(p => p.LicensePlate).NotNull().WithMessage("License plate is a required field");
            RuleFor(p => p.VehicleType).NotNull().WithMessage("Vehicle type is a required field");
        }
    }
}