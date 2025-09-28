using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Interfaces;
using System.Threading.Tasks;
using Models.Data.Contexts;

namespace Models.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddProduct(Product product)
    {
       await _context.Products.AddAsync(product);
    }

    public async Task<Product> GetProduct(int productId)
    {
        return  await _context.Products.Include(x => x.Categories)                          
                                        .AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == productId);
    }

    public async Task<List<Product>> GetAllProducts()
    {
        return await _context.Products.Include(x => x.Categories).AsNoTracking().ToListAsync();
    }

    public async Task RemoveProduct(int productId)
    {
        var productToBeDeleted = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

        if(productToBeDeleted != null)
        {
            _context.Products.Remove(productToBeDeleted);
        }
    }

    public async Task UpdateProduct(Product product)
    {
        var productToUpdate = await _context.Products.Include(x => x.Categories)
                                    .Where(x => x.ProductId == product.ProductId).FirstOrDefaultAsync();

        if(productToUpdate != null)
        {
            productToUpdate.Descritpion = product.Descritpion;
            productToUpdate.Price = product.Price;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.StockQuantity = product.StockQuantity;
            productToUpdate.Categories = product.Categories;
        }

    }
}
