using DataBase.Data;
using Logic.Container;
using Interfaces.RequestBody;
using Microsoft.AspNetCore.Mvc;

namespace DataSpeedrunsaver.Controllers
{
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly DBSpeedrunsaverContext _context;
        private readonly CategoryContainer _categoryContainer;

        public CategoryController(ILogger<UserController> logger)
        {
            _context = new DBSpeedrunsaverContext();
            _categoryContainer = new CategoryContainer(_context);
            _logger = logger;
        }

        [HttpGet]
        [Route("/Category/All")]
        public async Task<IActionResult> GetCategories() 
        {
            return Ok(await _categoryContainer.GetCategories());
        }

        [HttpGet]
        [Route("/Category/Specific")]
        public async Task<IActionResult> GetCategory(int id)
        {
            return Ok(await _categoryContainer.GetCategory(id));
        }

        [HttpPost]
        [Route("/Category/Create")]
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
    }
}
