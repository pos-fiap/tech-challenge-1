using Microsoft.Extensions.DependencyInjection;
using RCLocacoes.Application.Interfaces;
using RCLocacoes.Application.Services;

namespace RCLocacoes.Infra.Ioc.Services
{
    public static class AppServices
    {
        public static void RegisterAppServices(IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
