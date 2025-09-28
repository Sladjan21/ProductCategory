using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Infrastructure.Data.Contexts
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.ProductId).IsClustered(false);

                entity.HasMany(x => x.Categories).WithMany(x => x.Products);
            });

            modelBuilder.Entity<Category>(entity =>
            {

                entity.HasKey(x => x.CategoryId).IsClustered(false);

                entity.HasMany(x => x.Products).WithMany(x => x.Categories);
            });
        }
    }
}
