using FluentValidation;
using TechChallenge.Application.DTOs;

namespace TechChallenge.Application.Validator
{
    public class ReservationValidator : AbstractValidator<ReservationDto>
    {
        public ReservationValidator()
        {
        }
    }
}