using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DataBase;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NewshoreContext>(options => options.UseSqlServer(configuration.GetConnectionString("NewshoreDB"), b => b.MigrationsAssembly("Api")));

            services
                .AddTransient<IStoreRepository, StoreRepository>()
                .AddTransient<IAccountRepository, AccountRepository>()
                .AddTransient<IMessageRepository, MessageRepository>();
            
            return services;
        }

    }
}
