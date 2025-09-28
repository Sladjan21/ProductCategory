using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public DateTime CreatedAt { get; set; }
    //public virtual ICollection<ProductCategory> ProductCategories { get; set; } = [];
    public virtual ICollection<Product> Products { get; set; } = [];
}
