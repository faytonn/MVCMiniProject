using CoreLayer.Entities;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace MVCMiniProject.DataAccessLayer
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Attendance> Services { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Setting> Settings { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasOne(c => c.Parent).WithMany(c => c.Children).HasForeignKey(c => c.ParentId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProductTag>().HasKey(pt => new { pt.ProductId, pt.TagId });

            builder.Entity<ProductTag>().HasOne(pt => pt.Product).WithMany(p => p.ProductTags).HasForeignKey(pt => pt.ProductId);

            builder.Entity<ProductTag>().HasOne(pt => pt.Tag).WithMany(t => t.ProductTags).HasForeignKey(pt => pt.TagId);

            builder.Entity<ProductImage>().HasOne(pi => pi.Product).WithMany(p => p.ProductImages).HasForeignKey(pi => pi.ProductId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BasketItem>().HasOne(bi => bi.Product).WithMany(p => p.BasketItems).HasForeignKey(bi=>bi.ProductId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BasketItem>().HasOne(bi=>bi.User).WithMany().HasForeignKey(bi=>bi.UserId).OnDelete(DeleteBehavior.NoAction);
           
            builder.Entity<Category>().HasIndex(c => c.ParentId);

            builder.Entity<ProductTag>().HasIndex(pt => pt.ProductId);

            builder.Entity<ProductTag>().HasIndex(pt => pt.TagId);

            builder.Entity<BasketItem>().HasIndex(bi => bi.ProductId);
        }

    }
}
