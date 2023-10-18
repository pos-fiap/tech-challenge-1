using FluentValidation;
using TechChallenge.Application.DTOs;

namespace TechChallenge.Application.Validator
{
    public class RoleUpdateValidator : AbstractValidator<RoleUpdateDto>
    {
        public RoleUpdateValidator()
        {
            RuleFor(p => p.Id).NotNull().WithMessage("Id is a required field");
            RuleFor(p => p.Description).NotNull().WithMessage("Description is a required field");
        }
    }
}
