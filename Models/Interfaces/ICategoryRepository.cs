using Models.Entities;

namespace Models.Interfaces;
public interface ICategoryRepository
{
    Task<List<Category>> GetAllCategories();
    Task<List<Category>> GetCategoriesByIds(List<int> ids);
}
