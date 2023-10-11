using Interfaces.DB.DAL;
using Interfaces.DTO;
using Microsoft.EntityFrameworkCore;
using Interfaces.RequestBody;

namespace Logic.Container
{
    public class CategoryContainer
    {
        private readonly ICategoryDAL categoryDAL;

        public CategoryContainer(ICategoryDAL _categoryDAL)
        {
            categoryDAL = _categoryDAL;
        }

        public async Task<List<CategoryDTO>> GetCategories()
        {
            return await categoryDAL.GetCategories();
        }

        public async Task<CategoryDTO> GetCategory(int id)
        {
            return await categoryDAL.GetCategory(id);
        }

        public async Task<List<CategoryDTO>> GetCategoriesByGameId(int gameId)
        {
            return await categoryDAL.GetCategoriesByGameId(gameId);
        }
        
        public async Task CreateCategory(CategoryBody categoryBody) 
        {
            CategoryDTO categoryDTO = new CategoryDTO
            {
                CategoryName = categoryBody.CategoryName,
                CategoryDescription = categoryBody.CategoryDescription,
                gameId = categoryBody.gameId
            };
            await categoryDAL.CreateCategory(categoryDTO);
        }

        public async Task UpdateCategory(int id, CategoryBody categoryBody)
        {
            CategoryDTO categoryDTO = new CategoryDTO
            {
                Id = id,
                CategoryName = categoryBody.CategoryName,
                CategoryDescription = categoryBody.CategoryDescription,
                gameId = categoryBody.gameId
            };
            await categoryDAL.UpdateCategory(categoryDTO);
        }

        public async Task DeleteCategory(int id)
        {
            await categoryDAL.DeleteCategory(id);
        }
    }
}
