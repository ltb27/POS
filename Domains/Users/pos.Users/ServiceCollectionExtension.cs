using Microsoft.Extensions.DependencyInjection;
using pos.Users.Services;

namespace pos.Users;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddUserServices(this IServiceCollection services)
    {
        return services.AddScoped<IUserService, UserService>();
    }
}