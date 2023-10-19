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
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<ICustomerVehicleService, CustomerVehicleService>();
            services.AddScoped<IParkingSpotService, ParkingSpotService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IValetService, ValetService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleAccessService, RoleAccessService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
