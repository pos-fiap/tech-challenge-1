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
            services.AddScoped<IValidator<CarDto>, CarValidator>();
            services.AddScoped<IValidator<CostumerDto>, CostumerValidator>();
            services.AddScoped<IValidator<ParkingDto>, ParkingValidator>();
            services.AddScoped<IValidator<ValetDto>, ValetValidator>();
            services.AddScoped<IValidator<UserRoleDto>, UserRoleValidator>();
            services.AddScoped<IValidator<RoleDto>, RoleValidator>();
            services.AddScoped<IValidator<LoginDto>, LoginValidator>();
            services.AddScoped<IValidator<CustomerDto>, CustomerValidator>();
        }
    }
}
