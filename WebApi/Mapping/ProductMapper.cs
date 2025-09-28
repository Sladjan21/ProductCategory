using Models.DTOs.Product;
using Models.Entities;
using Models.DTOs;

namespace Models.Mapping;
public static class ProductMapper
{
    public static ProductDTO ToReadDto(this Product product)
    {
        return new ProductDTO
        {
            Id = product.ProductId,
            Description = product.Descritpion,
            Name = product.ProductName,
            Price = product.Price,
            Quantity = product.StockQuantity,
            Categories = product.Categories.Select(x => x.CategoryId).ToList()
        };
    }

    public static List<ProductDTO> ToReadDTO(this List<Product> productList)
    {
        var dtoList = new List<ProductDTO>();

        foreach (var item in productList)
        {
            var dto = new ProductDTO
            {
                Id = item.ProductId,
                Description = item.Descritpion,
                Name = item.ProductName,
                Price = item.Price,
                Quantity = item.StockQuantity,
                Categories = item.Categories.Select(x => x.CategoryId).ToList()
            };

            dtoList.Add(dto);
        }

        return dtoList;
    }

    public static Product ToEntity(this ProductCreateDTO dto, List<Category> categories)
    {
        return new Product
        {
            ProductName = dto.Name,
            Descritpion = dto.Description,
            Price = dto.Price,
            StockQuantity = dto.Quantity,
            Categories = categories
        };
    }

    public static Product ToEntity(this ProductDTO dto, List<Category> categories)
    {
        return new Product
        {
            ProductId = dto.Id,
            ProductName = dto.Name,
            Descritpion = dto.Description,
            Price = dto.Price,
            StockQuantity = dto.Quantity,
            Categories = categories
        };
    }
}
