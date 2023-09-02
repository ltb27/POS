using Microsoft.Extensions.DependencyInjection;
using pos.Products.Services;

namespace pos.Products;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddProductServices(this IServiceCollection services) => services.AddScoped<IProductService, ProductService>();
}