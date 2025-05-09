using AuthService.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AuthService.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(entity => entity.Id);
                entity.Property(e => e.Desactivated)
                        .HasDefaultValue(false);
                entity.Property(e => e.Deleted)
                        .HasDefaultValue(false);
                entity.Property(e => e.IdRole)
                        .HasDefaultValueSql("1");
                entity.Property(e => e.CreatedAt)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.HasOne(e => e.RoleNavegation)
                    .WithMany(e => e.UserNavegation)
                    .HasForeignKey(e => e.IdRole)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_User_Roles");
            });


            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(entity => entity.Id);
                entity.Property(e => e.CreatedAt)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");
                
                entity.Property(e => e.DeletedAt)
                        .HasDefaultValue(null);
                entity.Property(e => e.UpdatedAt)
                        .HasDefaultValue(null);
                entity.Property(e => e.Deleted)
                        .HasDefaultValue(false);
            });



                
        }

    }
}
