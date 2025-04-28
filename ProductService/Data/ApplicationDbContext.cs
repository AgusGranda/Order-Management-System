using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(entity => entity.IdProduct);

                entity.Property(e=> e.Desactivated)
                        .HasDefaultValue(false);

                entity.Property(e => e.Deleted)
                        .HasDefaultValue(false);
                entity.Property(e => e.CreatedAt)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasKey(e => e.IdProductImage);

                entity.HasOne(e => e.ProductNavegation)
                    .WithMany(e => e.Images)
                    .HasForeignKey(e => e.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductImage_Products");

                entity.Property(e => e.Desactivated)
                        .HasDefaultValue(false);
                entity.Property(e => e.Deleted)
                        .HasDefaultValue(false);
                entity.Property(e => e.CreatedAt)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

        }
    }
}
