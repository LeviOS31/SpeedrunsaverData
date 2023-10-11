using DataBase.Data;
using Logic.Container;
using Microsoft.AspNetCore.Mvc;
using Interfaces.RequestBody;
using DataBase.DAL;

namespace DataSpeedrunsaver.Controllers
{
    [ApiController]
    public class SpeedrunController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly SpeedrunContainer _speedrunContainer;

        public SpeedrunController(ILogger<UserController> logger, DBSpeedrunsaverContext dbcontext)
        {
            SpeedrunDAL speedrunDAL = new SpeedrunDAL(dbcontext);
            _speedrunContainer = new SpeedrunContainer(speedrunDAL);
            _logger = logger;
        }

        [HttpGet]
        [Route("/Speedrun/All")]
        public async Task<IActionResult> GetSpeedruns()
        {
            return Ok(await _speedrunContainer.GetSpeedruns());
        }

        [HttpGet]
        [Route("/Speedrun/Specific")]
        public async Task<IActionResult> GetSpeedrun(int id)
        {
            return Ok(await _speedrunContainer.GetSpeedrun(id));
        }

        [HttpGet]
        [Route("/Speedrun/Category")]
        public async Task<IActionResult> GetSpeedrunsByCategory(int id)
        {
            return Ok(await _speedrunContainer.GetSpeedrunsByCategory(id));
        }

        [HttpPost]
        [Route("/Speedrun/Create")]
        public async Task<IActionResult> CreateSpeedrun([FromBody] SpeedrunBody body)
        {
            try
            {
                await _speedrunContainer.Createspeedrun(body);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong when trying to create speedrun: " + e.Message);
            }
        }
    }
}
