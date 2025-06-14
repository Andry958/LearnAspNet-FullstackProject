using Backend.Model;
using Microsoft.EntityFrameworkCore;
namespace Backend.Model
{
    public class ProductDb : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductDb(DbContextOptions<ProductDb> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProductSqlServer;Trusted_Connection=True;");
        }

    }
}
