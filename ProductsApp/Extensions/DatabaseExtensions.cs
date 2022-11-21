using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductsApp.Infrastructure;

namespace ProductsApp.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class DatabaseExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, string connectionString)
        {
            return services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<AppDbContext>(opt =>
                {
                    opt.UseSqlServer(
                        connectionString,
                        x =>
                        {
                            //x.MigrationsAssembly(typeof(Startup)
                            //    .GetTypeInfo()
                            //    .Assembly
                            //    .GetName().Name);

                            x.MigrationsAssembly("ProductsApp.Infrastructure");
                        });
                });
        }
    }
}