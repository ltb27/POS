using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using pos.Data;

namespace pos.Web;

public class TenantDbContextFactory : IDesignTimeDbContextFactory<TenantDbContext>
{
    public TenantDbContext CreateDbContext(string[] args)
    {
        var configurationBuilder =
            new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json")
                .AddJsonFile("appsettings.Production.json");

        var configuration = configurationBuilder.Build();
        var connectionString = configuration.GetConnectionString("TenantConnection");

        var dbContextOptionBuilder = new DbContextOptionsBuilder<TenantDbContext>();
        dbContextOptionBuilder.UseSqlServer(connectionString);
        return new TenantDbContext(dbContextOptionBuilder.Options);
    }
}