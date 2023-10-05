using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RCLocacoes.Application.DTOs;
using RCLocacoes.Application.Validator;

namespace RCLocacoes.Infra.Ioc.Services
{
    public static class ValidatorServices
    {
        public static void RegisterValidatorServices(IServiceCollection services)
        {
            services.AddScoped<IValidator<AddressDto>, AddressValidator>();
            services.AddScoped<IValidator<UserDto>, UserValidator>();
        }
    }
}
