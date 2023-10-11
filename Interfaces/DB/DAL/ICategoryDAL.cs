using Interfaces.DTO;

namespace Interfaces.DB.DAL
{
    public interface ICategoryDAL
    {
        public Task<List<CategoryDTO>> GetCategories();
        public Task<CategoryDTO> GetCategory(int id);
        public Task<List<CategoryDTO>> GetCategoriesByGameId(int gameId);
        public Task CreateCategory(CategoryDTO categoryBody);
        public Task UpdateCategory(CategoryDTO categoryBody);
        public Task DeleteCategory(int id);
    }
}
