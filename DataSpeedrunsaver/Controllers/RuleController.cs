using Microsoft.AspNetCore.Mvc;
using DataBase.Data;
using Logic.Container;
using Interfaces.RequestBody;
using DataBase.DAL;

namespace DataSpeedrunsaver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RuleController : Controller
    {
        private readonly ILogger<RuleController> _logger;
        private readonly RuleContainer _ruleContainer;

        public RuleController(ILogger<RuleController> logger, DBSpeedrunsaverContext dbcontext)
        {
            RuleDAL ruleDAL = new RuleDAL(dbcontext);
            _ruleContainer = new RuleContainer(ruleDAL);
            _logger = logger;
        }

        [HttpGet]
        [Route("/Rule/All")]
        public async Task<IActionResult> GetRules()
        {
            return Ok(await _ruleContainer.GetRules());
        }

        [HttpGet]
        [Route("/Rule/Specific")]
        public async Task<IActionResult> GetRule(int id)
        {
            return Ok(await _ruleContainer.GetRule(id));
        }

        [HttpPost]
        [Route("/Rule/Create")]
        public async Task<IActionResult> CreateRule([FromBody] RuleBody body)
        {
            try
            {
                await _ruleContainer.CreateRule(body);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong when trying to create rule: " + e.Message);
            }
        }

    }
}
