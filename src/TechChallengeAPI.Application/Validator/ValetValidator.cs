using FluentValidation;
using TechChallenge.Application.DTOs;

namespace TechChallenge.Application.Validator
{
    public class ValetValidator : AbstractValidator<ValetDto>
    {
        public ValetValidator()
        {
            RuleFor(p => p.CPF).NotNull().WithMessage("CPF is a required field");
            RuleFor(p => p.Name).NotNull().WithMessage("Name is a required field");
            RuleFor(p => p.BirthDate).NotNull().WithMessage("BirthDate is a required field");
        }
    }
}