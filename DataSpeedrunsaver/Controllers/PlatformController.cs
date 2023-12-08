using Microsoft.AspNetCore.Mvc;
using Logic.Container;
using Interfaces.RequestBody;
using Interfaces.DB;
using Interfaces.DB.DAL;

namespace DataSpeedrunsaver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformController : Controller
    {
        private readonly ILogger<PlatformController> _logger;
        private readonly PlatformContainer _plaformContainer;
        
        public PlatformController(ILogger<PlatformController> logger, IDalFactory dalFactory) 
        {
            IPlatformDAL plaformDAL = dalFactory.GetPlatformDAL();
            _plaformContainer = new PlatformContainer(plaformDAL);
            _logger = logger;
        }

        [HttpGet]
        [Route("/Platform/All")]
        public async Task<IActionResult> GetPlatforms()
        {
            return Ok(await _plaformContainer.GetPlatforms());
        }

        [HttpGet]
        [Route("/Platform/Specific")]
        public async Task<IActionResult> GetPlatform(int id)
        {
            return Ok(await _plaformContainer.GetPlatform(id));
        }

        [HttpPost]
        [Route("/Platform/Create")]
        public async Task<IActionResult> CreatePlatform([FromBody] PlatformBody body)
        {
            try
            {
                await _plaformContainer.CreatePlatform(body);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong when trying to create platform: " + e.Message);
            }
        }
    }
}
