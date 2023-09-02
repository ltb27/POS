using Microsoft.EntityFrameworkCore;

namespace pos.Data;

public interface ITenantDbContextFactory : IDbContextFactory<TenantDbContext> { }

public class TenantDbContextFactory : ITenantDbContextFactory
{
    private readonly DbContextOptions<TenantDbContext> options;

    public TenantDbContextFactory(DbContextOptions<TenantDbContext> options)
    {
        this.options = options;
    }

    public TenantDbContext CreateDbContext()
    {
        var context = new TenantDbContext(options);
        // config db
        return context;
    }
}
