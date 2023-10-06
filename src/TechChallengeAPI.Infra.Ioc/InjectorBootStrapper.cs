using Microsoft.Extensions.DependencyInjection;
using RCLocacoes.Infra.Ioc.Services;

namespace RCLocacoes.Infra.Ioc
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
