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
        }

        public async Task<CategoryDTO> GetCategory(int id)
        {
        }

        public async Task<List<CategoryDTO>> GetCategoriesByGameId(int gameId)
        {
        }
        
        public async Task CreateCategory(CategoryBody categoryBody) 
        {
            CategoryDTO category;
        }
    }
}
