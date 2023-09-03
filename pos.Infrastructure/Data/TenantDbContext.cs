using Microsoft.EntityFrameworkCore;
using pos.Core.Entitites;
using pos.Infrastructure.Data.Configurations;

namespace pos.Infrastructure.Data;

public class TenantDbContext : DbContext
{
    public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }

    public DbSet<Product> Products { get; set; }
}