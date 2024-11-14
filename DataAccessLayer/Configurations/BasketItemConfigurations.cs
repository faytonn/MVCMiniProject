using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DAL.Configurations
{
    internal class BasketItemConfigurations : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.HasOne(bi => bi.Product).WithMany(p => p.BasketItems).HasForeignKey(bi => bi.ProductId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bi => bi.User).WithMany().HasForeignKey(bi => bi.UserId).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Quantity).HasDefaultValue(0);
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

            builder.HasIndex(bi => bi.ProductId);
        }
    }
}
