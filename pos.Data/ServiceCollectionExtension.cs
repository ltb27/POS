using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace pos.Data;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDataServices(this IServiceCollection services,string connectionString,
        bool sentitiveData, bool detailedErrors)
    {
        return services
            .AddTenantDbContext(connectionString, sentitiveData, detailedErrors)
            .AddScoped<ITenantDbContextFactory, TenantDbContextFactory>();
    }

    private static IServiceCollection AddTenantDbContext(this IServiceCollection services, string connectionString,
        bool sentitiveData, bool detailedErrors)
    {
#if DEBUG
        sentitiveData = true;
        detailedErrors = true;
#endif
        return services
                .AddDbContextFactory<TenantDbContext>(builder =>
                    {
                        builder.UseSqlServer(
                                connectionString
                            ).EnableSensitiveDataLogging(sentitiveData)
                            .EnableDetailedErrors(detailedErrors)
#if DEBUG
                            .LogTo(Console.WriteLine);
#endif
                    }
                )
            ;
    }
}