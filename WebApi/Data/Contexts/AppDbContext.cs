using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Models.Data.Contexts
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasMany(p => p.Categories)
            .WithMany(c => c.Products)
            .UsingEntity<Dictionary<string, object>>(
                "ProductCategories",
                j => j.HasOne<Category>()
                      .WithMany()
                      .HasForeignKey("CategoryId")
                      .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Product>()
                      .WithMany()
                      .HasForeignKey("ProductId")
                      .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("ProductId", "CategoryId");
                    j.ToTable("ProductCategories");
                    j.HasData(
                                    new { ProductId = 1, CategoryId = 1 },
                                    new { ProductId = 2, CategoryId = 1 },
                                    new { ProductId = 2, CategoryId = 2 });
                });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(x => x.CategoryId).IsClustered(false);

                entity.HasMany(x => x.Products).WithMany(x => x.Categories);

                entity.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");

                //seeding 
                entity.HasData(
                    new Category { CategoryId = 1, CategoryName = "Telefon", CreatedAt = new DateTime(2025,1,1) },
                    new Category { CategoryId = 2, CategoryName = "Laptop", CreatedAt = new DateTime(2025, 1, 1) }
                );
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.ProductId).IsClustered(false);

                entity.HasMany(x => x.Categories).WithMany(x => x.Products);

                entity.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");

                //seeding
                entity.HasData(
                    new Product { ProductId = 1, 
                                  ProductName = "Samsung S24",
                                  CreatedAt = new DateTime(2025,1,1),
                                  Descritpion = "120HZ disaply screen, long battery life",
                                  Price = 900, StockQuantity = 10
                    },
                    new Product { ProductId = 2,
                                  ProductName = "Mis", 
                                  Descritpion = "Logitech M24",
                                  CreatedAt = new DateTime(2025,1,1),
                                  Price = 100,
                                  StockQuantity = 10 
                    }
                );
            });


        }
    }
}
