using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pos.Core.Entitites;

namespace pos.Infrastructure.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", "products");
        builder.Property(x => x.ProductName).HasMaxLength(250).IsRequired();
        builder.HasIndex(x => x.ProductName).IsUnique();
        builder.Property(x => x.ImportPrice).HasPrecision(18, 2);
        builder.Property(x => x.SalesPrice).HasPrecision(18, 2);
        builder.Property(x => x.WholesalesPrice).HasPrecision(18, 2);
    }
}