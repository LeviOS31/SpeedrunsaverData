using Interfaces.DB;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore;

namespace Logic.Container
{
    public class CategoryContainer
    {
        private readonly IDBContext _dbContext;

        public CategoryContainer(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }
    }
}
