using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Product;
public class ProductCreateDTO
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public List<int> Categories { get; set; }
}
