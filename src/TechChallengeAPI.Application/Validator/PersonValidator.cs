using FluentValidation;
using TechChallenge.Application.DTOs;

namespace TechChallenge.Application.Validator
{
    public class PersonValidator : AbstractValidator<PersonDTO>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Status).NotNull().WithMessage("Status is a required field");
            RuleFor(p => p.Name).NotNull().WithMessage("Name is a required field");
            RuleFor(p => p.Document).NotNull().WithMessage("Document is a required field").MaximumLength(15).WithMessage("Document cannot be greater than 15");
        }
    }
}
