using FluentValidation;
using RCLocacoes.Application.DTOs;

namespace RCLocacoes.Application.Validator
{
    public class AddressValidator : AbstractValidator<AddressDto>
    {
        public AddressValidator()
        {
            RuleFor(p => p.Street).NotNull().WithMessage("Street is a required field");
            RuleFor(p => p.State).NotNull().WithMessage("State is a required field");
            RuleFor(p => p.AdditionalDetails).NotNull().WithMessage("AdditionalDetails is a required field");
            RuleFor(p => p.City).NotNull().WithMessage("City is a required field");
            RuleFor(p => p.Country).NotNull().WithMessage("Country is a required field");
            RuleFor(p => p.ZipCode).NotNull().WithMessage("ZipCode is a required field");
            RuleFor(p => p.Number).NotNull().WithMessage("Number is a required field");
        }
    }
}
