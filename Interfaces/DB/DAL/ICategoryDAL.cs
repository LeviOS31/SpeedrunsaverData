using Interfaces.DTO;
using Interfaces.RequestBody;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DB.DAL
{
    public interface ICategoryDAL
    {
        public Task<List<CategoryDTO>> GetCategories();

        public Task<CategoryDTO> GetCategory(int id);

        public Task<List<CategoryDTO>> GetCategoriesByGameId(int gameId);

        public Task CreateCategory(CategoryBody categoryBody);
    }
}
