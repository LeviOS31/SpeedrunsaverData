using Interfaces.DB.DAL;
using Interfaces.DTO;

namespace Test.Mock
{
    public class CategoryMock: ICategoryDAL
    {
        List<CategoryDTO> categories = new List<CategoryDTO>
        {
            new CategoryDTO { Id = 1, CategoryName = "Category 1", gameId = 2 },
            new CategoryDTO { Id = 2, CategoryName = "Category 2", gameId = 1 },
            new CategoryDTO { Id = 3, CategoryName = "Category 3", gameId = 1 },
        };
        public async Task<List<CategoryDTO>> GetCategories()
        {
            return categories;
        }
        public async Task<CategoryDTO> GetCategory(int id)
        {
            return categories.FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<CategoryDTO>> GetCategoriesByGameId(int gameId)
        {
            return categories.FindAll(c => c.gameId == gameId);
        }

        public async Task CreateCategory(CategoryDTO categoryDTO)
        {
            categoryDTO.Id = categories.Count + 1;
            categories.Add(categoryDTO);
        }
        public async Task UpdateCategory(CategoryDTO categoryDTO)
        {
            categories.Remove(categories.Find(x => x.Id == categoryDTO.Id));
            categories.Add(categoryDTO);
        }
        public async Task DeleteCategory(int id)
        {
            categories.Remove(categories.Find(x => x.Id == id));
        }
    }
}
