using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Validator
{
<<<<<<<< HEAD:src/TechChallengeAPI.Application/Validator/CustomerValidator.cs
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
========
    public class CostumerValidator : AbstractValidator<CostumerDto>
    {
        public CostumerValidator()
>>>>>>>> 2a00abc54098f34cf5a5a789647fd0c53560a41e:src/TechChallengeAPI.Application/Validator/CostumerValidator.cs
        {
            RuleFor(p => p.PersonalInformations.Status).NotNull().WithMessage("Status is a required field");
            RuleFor(p => p.PersonalInformations.Name).NotNull().WithMessage("Name is a required field");
            RuleFor(p => p.PersonalInformations.Document).NotNull().WithMessage("Document is a required field");
        }
       
    }
}
