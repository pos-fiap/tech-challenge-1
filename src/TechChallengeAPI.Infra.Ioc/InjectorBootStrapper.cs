using Microsoft.Extensions.DependencyInjection;
using TechChallenge.Infra.Ioc.Services;

namespace TechChallenge.Infra.Ioc
{
    public static class InjectorBootStrapper
    {
        public static void Setup(IServiceCollection services)
        {
            AppServices.RegisterAppServices(services);
            DataServices.RegisterDataServices(services);
            ValidatorServices.RegisterValidatorServices(services);
            AutoMapperServices.RegisterAutoMapperServices(services);
        }

    }
}
