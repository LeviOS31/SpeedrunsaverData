using DataBase.Data;
using Interfaces.RequestBody;
using Logic.Container;
using Microsoft.AspNetCore.Mvc;

namespace DataSpeedrunsaver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly DBSpeedrunsaverContext _context;
        private readonly GameContainer _gameContainer;

        public GameController(ILogger<GameController> logger)
        {
            _context = new DBSpeedrunsaverContext();
            _gameContainer = new GameContainer(_context);
            _logger = logger;
        }

        [HttpGet]
        [Route("/Game/All")]
        public async Task<IActionResult> GetGames() 
        {
            return Ok(await _gameContainer.GetGames());
        }

        [HttpGet]
        [Route("/Game/Specific")]
        public async Task<IActionResult> GetGame(int id) 
        {
            return Ok(await _gameContainer.GetGame(id));
        }

        [HttpPost]
        [Route("/Game/Create")]
        public async Task<IActionResult> CreateGame([FromBody] GameBody body) 
        {
            try 
            {
                await _gameContainer.CreateGame(body);
                return Ok();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong when trying to create game: " + e.Message);
            }
        }
    }
}
