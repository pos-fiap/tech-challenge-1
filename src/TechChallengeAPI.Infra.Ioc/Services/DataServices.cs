using Microsoft.Extensions.DependencyInjection;
using TechChallenge.Application.Interfaces;
using TechChallenge.Application.Services;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Infra.Data;
using TechChallenge.Infra.Data.Repositories;

namespace TechChallenge.Infra.Ioc.Services
{
    public static class DataServices
    {
        public static void RegisterDataServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
