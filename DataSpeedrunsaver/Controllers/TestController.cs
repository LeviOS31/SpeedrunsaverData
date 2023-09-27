using DataBase.Data;
using Microsoft.AspNetCore.Mvc;
using Logic.Container;

namespace DataSpeedrunsaver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly DBSpeedrunsaverContext _dbContext;
        private readonly UserContainer _userContainer;
        private readonly GameContainer _gameContainer;
        private readonly CategoryContainer _categoryContainer;
        private readonly CommentContainer _commentContainer;
        private readonly SpeedrunContainer _speedrunContainer;
        private readonly PlatformContainer _platformContainer;
        private readonly RuleContainer _ruleContainer;


        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
            _dbContext = new DBSpeedrunsaverContext();
            _userContainer = new UserContainer(_dbContext);
            _gameContainer = new GameContainer(_dbContext);
            _categoryContainer = new CategoryContainer(_dbContext);
            _commentContainer = new CommentContainer(_dbContext);
            _speedrunContainer = new SpeedrunContainer(_dbContext);
            _platformContainer = new PlatformContainer(_dbContext);
            _ruleContainer = new RuleContainer(_dbContext);
        }

        [HttpGet]
        [Route("/Test/Games")]
        public async Task<IActionResult> GetGames()
        {

            return Ok(await _gameContainer.GetGames());
        }

        [HttpGet]
        [Route("/Test/Platforms")]
        public async Task<IActionResult> GetPlatforms()
        {

            return Ok(await _platformContainer.GetPlatforms());
        }

        [HttpGet]
        [Route("/Test/Categories")]
        public async Task<IActionResult> GetCategories()
        {

            return Ok(await _categoryContainer.GetCategories());
        }

        [HttpGet]
        [Route("/Test/Comments")]
        public async Task<IActionResult> GetComments()
        {

            return Ok(await _commentContainer.GetComments());
        }

        [HttpGet]
        [Route("/Test/Speedruns")]
        public async Task<IActionResult> GetSpeedruns()
        {

            return Ok(await _speedrunContainer.GetSpeedruns());
        }

        [HttpGet]
        [Route("/Test/Rules")]
        public async Task<IActionResult> GetRules()
        {

            return Ok(await _ruleContainer.GetRules());
        }
    }
}
