using Application.Contracts.Persistence;
using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAccountServices, AccountServices>();
            services.AddTransient<IMessageServices, MessageServices>();

            return services;
        }

    }
}
