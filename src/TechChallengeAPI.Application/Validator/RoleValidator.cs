using FluentValidation;
using TechChallenge.Application.DTOs;

namespace TechChallenge.Application.Validator
{
    public class RoleValidator : AbstractValidator<RoleDto>
    {
        public RoleValidator()
        {         
            RuleFor(p => p.Description).NotNull().WithMessage("Description is a required field");
        }
    }
}
