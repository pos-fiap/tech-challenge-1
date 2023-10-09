using Microsoft.Extensions.DependencyInjection;
using TechChallenge.Application.Interfaces;
using TechChallenge.Application.Services;

namespace TechChallenge.Infra.Ioc.Services
{
    public static class AppServices
    {
        public static void RegisterAppServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IRoleService, RoleService>();
        }
    }
}
