using FluentValidation;
using TechChallenge.Application.DTOs;

namespace TechChallenge.Application.Validator
{
    public class UserRoleValidator : AbstractValidator<UserRoleDto>
    {
        public UserRoleValidator()
        {
            RuleFor(p => p.UserId).NotNull().WithMessage("UserId is a required field");
            RuleFor(p => p.Roles).NotNull().WithMessage("RoleIds is a required field");
        }
    }
}
