﻿using Microsoft.Extensions.DependencyInjection;
using TechChallenge.Application.Interfaces;
using TechChallenge.Application.Services;

namespace TechChallenge.Infra.Ioc.Services
{
    public static class AppServices
    {
        public static void RegisterAppServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IParkingService, ParkingService>();
            services.AddScoped<IValetService, ValetService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICostumerService, CostumerService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
