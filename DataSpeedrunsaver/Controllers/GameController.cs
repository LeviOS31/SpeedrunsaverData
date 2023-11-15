using DataBase.DAL;
using DataBase.Data;
using Interfaces.RequestBody;
using Logic.Container;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DataSpeedrunsaver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly GameContainer _gameContainer;
        private readonly UserContainer _userContainer;

        public GameController(ILogger<GameController> logger, DBSpeedrunsaverContext dbcontext)
        {
            GameDAL gameDAL = new GameDAL(dbcontext);
            _gameContainer = new GameContainer(gameDAL);

            UserDAL userdal = new UserDAL(dbcontext);
            UserTokenDAL tokendal = new UserTokenDAL(dbcontext);
            _userContainer = new UserContainer(userdal, tokendal);

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
                if (body.Token == null || body.userID == null)
                {
                    return StatusCode(401, "You need to be logged in to create a game");
                }
                else
                {
                    TokenBody token = new TokenBody
                    {
                        Token = body.Token,
                        AccesForAdmin = true,
                        userID = body.userID ?? 0
                    };

                    int id = await _userContainer.CheckifCorrect(token);
                    if (id < 1)
                    {
                        return StatusCode(401, "You need to be logged in or be an admin to create a game");
                    }

                    await _gameContainer.CreateGame(body);
                    return Ok();
                }
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
