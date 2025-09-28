using Models.DTOs;
using Models.Entities;

namespace WebApi.Mapping;
public static class CategoryMapper
{
    public static List<CategoryDTO> ToReadDTO(this List<Category> categoryList)
    {
        var dtoList = new List<CategoryDTO>();

        foreach (var item in categoryList)
        {
            var dto = new CategoryDTO
            {
                Id = item.CategoryId,
                Name = item.CategoryName
            };

            dtoList.Add(dto);
        }

        return dtoList;
    }

}

