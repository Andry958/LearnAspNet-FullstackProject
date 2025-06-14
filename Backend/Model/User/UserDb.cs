using Microsoft.EntityFrameworkCore;
using System;

namespace Backend.Model.User
{
    public class UserDb : DbContext
    {
        public UserDb(DbContextOptions<UserDb> options)
       : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // UserProduct: зв’язки
            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserProducts)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.Product)
                .WithMany() // якщо хочеш, можеш додати `.WithMany(p => p.UserProducts)`
                .HasForeignKey(up => up.ProductId);
        }
    }
}
