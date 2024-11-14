using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(1024);
        builder.Property(x => x.Price).HasDefaultValue(0).HasColumnType("decimal(10,2)");
        builder.Property(x => x.DiscountPrice).HasDefaultValue(0).HasColumnType("decimal(10,2)");
        builder.Property(x => x.IsAvailable).HasDefaultValue(false);
    }
}
