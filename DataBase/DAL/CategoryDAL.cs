using Interfaces.DB.DAL;
using Interfaces.DTO;
using DataBase.Data;
using Interfaces.RequestBody;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DataBase.DAL
{
    public class CategoryDAL: ICategoryDAL
    {
        private readonly DBSpeedrunsaverContext dbcontext;
        public CategoryDAL(DBSpeedrunsaverContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }
        public async Task<List<CategoryDTO>> GetCategories()
        {
            List<Category> dbcategories = await dbcontext.Categories.ToListAsync();
            List<CategoryDTO> categories = new List<CategoryDTO>();
            foreach (Category category in dbcategories)
            {
                categories.Add(new CategoryDTO
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    CategoryDescription = category.CategoryDescription,
                    gameId = category.gameId,
                });
            }
            return categories;
        }

        public async Task<CategoryDTO> GetCategory(int id)
        {
            Category category = await dbcontext.Categories.FindAsync(id);
            CategoryDTO categoryDTO = new CategoryDTO
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
                gameId = category.gameId,
            };
            return categoryDTO;
        }

        public async Task<List<CategoryDTO>> GetCategoriesByGameId(int gameId)
        {
            List<Category> dbcategories = await dbcontext.Categories
                .Where(category => category.gameId == gameId)
                .ToListAsync();
            List<CategoryDTO> categories = new List<CategoryDTO>();
            foreach (Category category in dbcategories)
            {
                categories.Add(new CategoryDTO
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    CategoryDescription = category.CategoryDescription,
                    gameId = category.gameId,
                });
            }
            return categories;
        }

        public async Task CreateCategory(CategoryDTO categoryDTO)
        {
            Category category = new Category
            {
                CategoryName = categoryDTO.CategoryName,
                CategoryDescription = categoryDTO.CategoryDescription,
                gameId = categoryDTO.gameId,
            };
            dbcontext.Categories.Add(category);
            await dbcontext.SaveChangesAsync();
        }

        public async Task UpdateCategory(CategoryDTO categoryDTO)
        {
            var entryupdate = await dbcontext.Categories.FindAsync(categoryDTO.Id);

            entryupdate.CategoryName = categoryDTO.CategoryName;
            entryupdate.CategoryDescription = categoryDTO.CategoryDescription;
            entryupdate.gameId = categoryDTO.gameId;

            dbcontext.Categories.Update(entryupdate);
            await dbcontext.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            Category category = await dbcontext.Categories.FindAsync(id);
            dbcontext.Categories.Remove(category);
            await dbcontext.SaveChangesAsync();
        }
    }
}
