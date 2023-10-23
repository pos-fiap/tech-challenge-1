using FluentValidation;
using TechChallenge.Application.DTOs;

namespace TechChallenge.Application.Validator
{
    public class CustomerVehicleValidator : AbstractValidator<CustomerVehicleDto>
    {
        public CustomerVehicleValidator()
        {
            //RuleFor(p => p.Plate).NotNull().WithMessage("Plate is a required field");
        }
    }
}