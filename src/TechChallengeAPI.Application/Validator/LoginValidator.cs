using FluentValidation;
using TechChallenge.Application.DTOs;

namespace TechChallenge.Application.Validator
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(p => p.Username)
                .NotEmpty()
                .WithMessage("Username is a required field");

            RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage("Password is a required field");
        }
    }
}
