using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCMiniProject.DataAccessLayer
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Setting> Settings { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().HasMany(p => p.Tags).WithMany(t => t.Products).UsingEntity(j => j.ToTable("ProductTags"));

            builder.Entity<ProductImage>().HasOne(pi => pi.Product).WithMany(p => p.ProductImages).HasForeignKey(pi => pi.ProductId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BasketItem>().HasOne(bi => bi.Product).WithMany(p => p.BasketItems).HasForeignKey(bi=>bi.ProductId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BasketItem>().HasOne(bi=>bi.User).WithMany().HasForeignKey(bi=>bi.UserId).OnDelete(DeleteBehavior.NoAction);
        }

    }
}
