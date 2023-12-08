using Microsoft.AspNetCore.Mvc;
using Logic.Container;
using Interfaces.RequestBody;
using DataBase.DAL;
using Interfaces.DTO;
using Interfaces.DB;
using Interfaces.DB.DAL;

namespace DataSpeedrunsaver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserContainer _userContainer;

        public UserController(ILogger<UserController> logger, IDalFactory dalFactory)
        {
            IUserDAL userdal = dalFactory.GetUserDAL();
            IUserTokenDAL tokendal = dalFactory.GetUserTokenDAL();
            _userContainer = new UserContainer(userdal, tokendal);
            _logger = logger;
        }

        [HttpGet]
        [Route("/User/All")]
        public async Task<IActionResult> GetUsers()
        {
            List<UserDTO> users = await _userContainer.GetUsers();
            foreach(UserDTO user in users)
            {
                user.Password = "";
                user.Email = "";
            }
            return Ok(users);
        }

        [HttpGet]
        [Route("/User/Specific")]
        public async Task<IActionResult> GetUser(int id)
        {
            UserDTO user = await _userContainer.GetUser(id);
            user.Password = "";
            return Ok(user);
            
        }

        [HttpPost]
        [Route("/User/Create")]
        public async Task<IActionResult> CreateUser([FromBody] UserBody body)
        {
            try 
            {
                await _userContainer.CreateUser(body);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong when trying to create user: " + e.Message);
            }
        }

        [HttpPost]
        [Route("/User/Validation")]
        public async Task<IActionResult> ValidateUser([FromBody] UserBody body) 
        {
            try 
            {
                UserTokenDTO token = await _userContainer.ValidateUser(body);
                if (token != null)
                {
                    return Ok(token);
                }
                else 
                {
                    throw new Exception("Invalid username or password");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong when trying to validate user: " + e.Message);
            }
        }

        [HttpPost]
        [Route("/User/Checks")]
        public async Task<IActionResult> CheckUserInfo([FromBody] TokenBody body)
        {
            try
            {
                int id = await _userContainer.CheckifCorrect(body);
                if (id > 0)
                {
                    return Ok(id);
                }
                else
                {
                    throw new Exception("Invalid user");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong when trying to validate user: " + e.Message);
            }
        }
    }
}