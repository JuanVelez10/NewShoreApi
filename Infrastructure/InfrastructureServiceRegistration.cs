using Application.Contracts.Infrastructure;
using Domain.Dtos;
using Infrastructure.Services.Integration;
using Infrastructure.Services.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Credential>(configuration.GetSection("Credential"));
            services.AddTransient<IMapperService, MapperServices>();
            services.AddTransient<INewshoreAirServices, NewshoreAirServices>();
            return services;
        }

    }
}
