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
    public class CostumerValidator : AbstractValidator<CostumerDto>
    {
        public CostumerValidator()
        {
            RuleFor(p => p.PersonalInformations.Status).NotNull().WithMessage("Status is a required field");
            RuleFor(p => p.PersonalInformations.Name).NotNull().WithMessage("Name is a required field");
            RuleFor(p => p.PersonalInformations.Document).NotNull().WithMessage("Document is a required field");
        }
       
    }
}
