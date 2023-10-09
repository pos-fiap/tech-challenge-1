using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
