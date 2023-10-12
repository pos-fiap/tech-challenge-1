using FluentValidation;
using TechChallenge.Application.DTOs;

namespace TechChallenge.Application.Validator
{
    public class ParkingValidator : AbstractValidator<ParkingDto>
    {
        public ParkingValidator()
        {
            RuleFor(p => p.CarId).NotNull().WithMessage("Model is a required field");
            RuleFor(p => p.ValetId).NotNull().WithMessage("Brand is a required field");
        }
    }
}