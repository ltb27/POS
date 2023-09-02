using Microsoft.EntityFrameworkCore;
using pos.Data.Entitites;

namespace pos.Data;

public class TenantDbContext : DbContext
{
    public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
    public DbSet<Product> Products { get; set; }
}