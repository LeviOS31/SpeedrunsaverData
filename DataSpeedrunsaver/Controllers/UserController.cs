using DataSpeedrunsaver.Models;
using Microsoft.AspNetCore.Mvc;
using DataSpeedrunsaver.Data;
using DataSpeedrunsaver.Models;

namespace DataSpeedrunsaver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUsers")]
        public IEnumerable<User> Get()
        {
            Console.WriteLine("GetUsers");
            using (var db = new DBSpeedrunsaverContext())
            {
                return db.Users.ToList();
            }
        }

        [HttpPost(Name = "CreateUser")]
        public void Post([FromBody] User user)
        {
            Console.WriteLine("CreateUser");
            using (var db = new DBSpeedrunsaverContext()) 
            {
                var newUser = new User 
                {
                    Username = user.Username,
                    Password = user.Password,
                    Country = user.Country,
                    Email = user.Email,
                    Admin = user.Admin
                };

                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }
    }
}