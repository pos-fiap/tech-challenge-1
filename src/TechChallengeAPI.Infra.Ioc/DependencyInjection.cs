using Microsoft.Extensions.DependencyInjection;

namespace RCLocacoes.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            InjectorBootStrapper.Setup(services);
        }
    }
}
