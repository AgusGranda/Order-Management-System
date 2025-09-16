using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(entity => entity.Id);
                entity.Property(e => e.Status)
                        .HasDefaultValue("Pending");
                entity.Property(e => e.ProductId)
                        .HasColumnType("int");
                entity.Property(e => e.UserId)
                        .HasColumnType("int");
                entity.Property(e => e.CreatedAt)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

        }
    }
}
