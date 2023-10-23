using FluentValidation;
using TechChallenge.Application.DTOs;

namespace TechChallenge.Application.Validator
{
    public class ValetValidator : AbstractValidator<ValetDto>
    {
        public ValetValidator()
        {
            RuleFor(p => p.CNH).NotNull().WithMessage("CNH is a required field");
            RuleFor(p => p.CNHExpiration).NotNull().WithMessage("CNH Expiration is a required field");
        }
    }
}