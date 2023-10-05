using Microsoft.Extensions.DependencyInjection;
using RCLocacoes.Domain.Entities;
using RCLocacoes.Domain.Interfaces;
using RCLocacoes.Infra.Data;
using RCLocacoes.Infra.Data.Repositories;

namespace RCLocacoes.Infra.Ioc.Services
{
    public static class DataServices
    {
        public static void RegisterDataServices(IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
