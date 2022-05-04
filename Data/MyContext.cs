using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductApplication.Models.Entities;
using ProductApplication.Models.Identity;

namespace ProductApplication.Data
{
    public class MyContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .Property(x => x.UnitPrice)
                .HasPrecision(8, 2);
            builder.Entity<SparePart>()
                .Property(x => x.UnitPrice)
                .HasPrecision(8, 2);
            builder.Entity<ProductSparePart>()
                .HasKey(x => new { x.ProductId, x.SparePartId });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<ProductSparePart> ProducSpareParts { get; set; }
    }
}