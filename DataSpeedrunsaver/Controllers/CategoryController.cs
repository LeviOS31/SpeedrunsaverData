using DataBase.Data;
using Logic.Container;
using Interfaces.RequestBody;
using Microsoft.AspNetCore.Mvc;
using DataBase.DAL;

namespace DataSpeedrunsaver.Controllers
{
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly CategoryContainer _categoryContainer;

        public CategoryController(ILogger<UserController> logger, DBSpeedrunsaverContext dbcontext)
        {
            CategoryDAL categoryDAL =  new CategoryDAL(dbcontext);
            _categoryContainer = new CategoryContainer(categoryDAL);
            _logger = logger;
        }

        [HttpGet]
        [Route("/Categories")]
        public async Task<IActionResult> GetCategories() 
        {
            return Ok(await _categoryContainer.GetCategories());
        }

        [HttpGet]
        [Route("/Categories/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            return Ok(await _categoryContainer.GetCategory(id));
        }

        [HttpGet]
        [Route("/Categories/game/{gameid}")]
        public async Task<IActionResult> GetCategoriesByGameId(int gameId)
        {
            return Ok(await _categoryContainer.GetCategoriesByGameId(gameId));
        }

        [HttpPost]
        [Route("/Categories")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryBody body) 
        {
            try 
            {
                await _categoryContainer.CreateCategory(body);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong when trying to create category: " + e.Message);
            }
        }

        [HttpPut]
        [Route("/Categories/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryBody body)
        {
            try
            {
                await _categoryContainer.UpdateCategory(id, body);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong when trying to update category: " + e.Message);
            }
        }

        [HttpDelete]
        [Route("/Categories/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryContainer.DeleteCategory(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong when trying to delete category: " + e.Message);
            }
        }
    }
}
