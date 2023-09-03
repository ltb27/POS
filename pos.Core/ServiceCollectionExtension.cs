using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pos.Infrastructure.Data;

namespace pos.Core;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services, string connectionString,
        bool sensitiveData, bool detailedErrors)
    {
        return services
            .AddTenantDbContext(connectionString, sensitiveData, detailedErrors)
            .AddScoped<ITenantDbContextFactory, TenantDbContextFactory>();
    }

    private static IServiceCollection AddTenantDbContext(this IServiceCollection services, string connectionString,
        bool sensitiveData = false, bool detailedErrors = false)
    {
#if DEBUG
        sensitiveData = true;
        detailedErrors = true;
#endif
        return services
                .AddDbContextFactory<TenantDbContext>(builder =>
                    {
                        builder.UseSqlServer(
                                connectionString
                            ).EnableSensitiveDataLogging(sensitiveData)
                            .EnableDetailedErrors(detailedErrors)
#if DEBUG
                            .LogTo(Console.WriteLine);
#endif
                    }
                )
            ;
    }
}