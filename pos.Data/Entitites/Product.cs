using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pos.Data.Entitites;

[Table("Product", Schema = "product")]
public class Product : BaseEntity
{
    public string ProductName { get; set; }
    [Precision(14, 2)] public decimal WholesalesPrice { get; set; }
    [Precision(14, 2)] public decimal SalesPrice { get; set; }
    [Precision(14, 2)] public decimal ImportPrice { get; set; }
}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.ProductName).IsRequired().HasMaxLength(25);
        builder.HasIndex(x => x.ProductName).IsUnique();
    }
}