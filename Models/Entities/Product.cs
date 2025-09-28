using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public string Descritpion { get; set; }
    public int StockQuantity { get; set; }
    public DateTime CreatedAt { get; set; }
    //public virtual ICollection<ProductCategory> ProductCategories { get; set; } = [];
    public virtual ICollection<Category> Categories { get; set; } = [];
}
