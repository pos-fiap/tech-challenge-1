using FluentValidation;
using TechChallenge.Application.DTOs;

namespace TechChallenge.Application.Validator
{
    public class CarValidator : AbstractValidator<CarDto>
    {
        public CarValidator()
        {
            RuleFor(p => p.Model).NotNull().WithMessage("Model is a required field");
            RuleFor(p => p.Brand).NotNull().WithMessage("Brand is a required field");
            RuleFor(p => p.Plate).NotNull().WithMessage("Plate is a required field");
        }
    }
}