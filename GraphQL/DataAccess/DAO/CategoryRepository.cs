using GraphQL.Data;
using GraphQL.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DAO
{
    public class CategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) => _context = context;

        public List<Category> GetAllCategories() => _context.Categories.ToList();

        public async Task<Category> CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}