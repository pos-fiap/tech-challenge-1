using FluentValidation;
using RCLocacoes.Application.DTOs;

namespace RCLocacoes.Application.Validator
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(p => p.Username).NotNull().WithMessage("Username is a required field");
            RuleFor(p => p.Password).NotNull().WithMessage("Password is a required field");
        }
    }
}
