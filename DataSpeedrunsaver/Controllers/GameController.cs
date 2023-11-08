using DataBase.DAL;
using DataBase.Data;
using Interfaces.RequestBody;
using Logic.Container;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DataSpeedrunsaver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly GameContainer _gameContainer;

        public GameController(ILogger<GameController> logger, DBSpeedrunsaverContext dbcontext)
        {
            GameDAL gameDAL = new GameDAL(dbcontext);
            _gameContainer = new GameContainer(gameDAL);
            _logger = logger;
        }

        [HttpGet]
        [Route("/Games")]
        public async Task<IActionResult> GetGames() 
        {
            return Ok(await _gameContainer.GetGames());
        }

        [HttpGet]
        [Route("/Games/id/{id}")]
        public async Task<IActionResult> GetGame(int id) 
        {
            return Ok(await _gameContainer.GetGame(id));
        }

        [HttpGet]
        [Route("/Games/name/{name}")]
        public async Task<IActionResult> GetGameByName(string name)
        {
            return Ok(await _gameContainer.GetGameByName(name));
        }

        [HttpPost]
        [Route("/Games")]
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

        [HttpPut]
        [Route("/Games/{id}")]
        public async Task<IActionResult> UpdateGame(int id, [FromBody] GameBody body)
        {
            try
            {
                await _gameContainer.UpdateGame(id, body);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong when trying to update game: " + e.Message);
            }
        }

        [HttpDelete]
        [Route("/Games/{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            try
            {
                await _gameContainer.DeleteGame(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong when trying to delete game: " + e.Message);
            }
        }
    }
}
