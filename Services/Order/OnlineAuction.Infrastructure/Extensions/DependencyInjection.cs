using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineAuction.Domain.Repositories.Base;
using OnlineAuction.Infrastructure.Data;
using OnlineAuction.Infrastructure.Repositories;
using OnlineAuction.Infrastructure.Repositories.Base;

namespace OnlineAuction.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<OrderContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
            //                                    ServiceLifetime.Singleton,
            //                                    ServiceLifetime.Singleton);

            services.AddDbContext<OrderContext>(options =>
                         options.UseSqlServer(
                             configuration.GetConnectionString("OrderConnection"),
                             b => b.MigrationsAssembly(typeof(OrderContext).Assembly.FullName)), ServiceLifetime.Singleton);

            //Add Repositories
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IOrderRepository), typeof(OrderRepository));
            return services;
        }
    }
}
