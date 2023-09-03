namespace pos.Web.Services;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInternalServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services
                .Configure<TokenSettings>(
                    configuration.GetSection("TokenSettings")
                ).AddScoped<ITokenService, TokenService>()
            ;
    }
}