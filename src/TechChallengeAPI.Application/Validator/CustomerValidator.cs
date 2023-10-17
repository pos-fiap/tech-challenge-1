using FluentValidation;
using TechChallenge.Application.DTOs;

namespace TechChallenge.Application.Validator
{
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.PersonalInformations.Status).NotNull().WithMessage("Status is a required field");
            RuleFor(p => p.PersonalInformations.Name).NotNull().WithMessage("Name is a required field");
            RuleFor(p => p.PersonalInformations.Document).NotNull().WithMessage("Document is a required field").MaximumLength(15).WithMessage("Document cannot be greater than 15");
        }
       
    }
}
