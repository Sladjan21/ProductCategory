using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task RemoveProduct(int productId);
        Task<Product> GetProduct(int productId);
        Task UpdateProduct(Product product);
        Task<List<Product>> GetAllProducts();
    }
}
