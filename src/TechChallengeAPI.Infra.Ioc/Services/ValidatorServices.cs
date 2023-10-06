using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Validator;

namespace TechChallenge.Infra.Ioc.Services
{
    public static class ValidatorServices
    {
        public static void RegisterValidatorServices(IServiceCollection services)
        {
            services.AddScoped<IValidator<UserDto>, UserValidator>();
            services.AddScoped<IValidator<UserRoleDto>, UserRoleValidator>();
        }
    }
}
