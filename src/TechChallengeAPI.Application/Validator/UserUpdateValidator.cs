﻿using FluentValidation;
using TechChallenge.Application.DTOs;

namespace TechChallenge.Application.Validator
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateValidator()
        {
            RuleFor(p => p.Username).NotNull().WithMessage("Username is a required field").EmailAddress().WithMessage("Username has to be a valid email");
            RuleFor(p => p.Password).NotNull().WithMessage("Password is a required field");
        }
    }
}
