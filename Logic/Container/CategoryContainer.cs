using Interfaces.DB;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using Interfaces.RequestBody;

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

        public async Task<Category> GetCategory(int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task<List<Category>> GetCategoriesByGameId(int gameId)
        {
            return await _dbContext.Categories.Where(x => x.gameId == gameId).ToListAsync();
        }
        
        public async Task CreateCategory(CategoryBody categoryBody) 
        {
            Category category = new Category
            {
                CategoryName = categoryBody.CategoryName,
                CategoryDescription = categoryBody.CategoryDescription,
                gameId = categoryBody.gameId
            };

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
