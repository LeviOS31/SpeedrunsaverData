﻿using Microsoft.AspNetCore.Mvc;
using DataBase.Data;
using Logic.Container;
using Interfaces.RequestBody;

namespace DataSpeedrunsaver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly DBSpeedrunsaverContext _context;
        private readonly UserContainer _userContainer;

        public UserController(ILogger<UserController> logger)
        {
            _context = new DBSpeedrunsaverContext();
            _userContainer = new UserContainer(_context);
            _logger = logger;
        }

        [HttpGet]
        [Route("/User/All")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userContainer.GetUsers());
        }

        [HttpGet]
        [Route("/User/Specific")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(await _userContainer.GetUser(id));
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
                int id = await _userContainer.ValidateUser(body);
                if (id != 0)
                {
                    return Ok(id);
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
    }
}