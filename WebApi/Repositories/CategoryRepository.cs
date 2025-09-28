using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Interfaces;
using Models.Data.Contexts;

namespace Models.Repositories;
public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;
    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<List<Category>> GetCategoriesByIds(List<int> ids)
    {
        return await _context.Categories.Where(x => ids.Contains(x.CategoryId)).ToListAsync();
    }
}

