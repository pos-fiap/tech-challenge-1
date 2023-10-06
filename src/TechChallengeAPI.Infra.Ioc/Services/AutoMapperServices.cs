using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace RCLocacoes.Infra.Ioc.Services
{
    public static class AutoMapperServices
    {
        public static void RegisterAutoMapperServices(IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(configuration =>
            {

            });
        }
    }
}
