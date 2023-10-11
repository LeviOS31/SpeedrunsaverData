using Microsoft.AspNetCore.Mvc;
using DataBase.Data;
using Logic.Container;
using Interfaces.RequestBody;
using DataBase.DAL;

namespace DataSpeedrunsaver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : Controller
    {
        private readonly ILogger<CommentController> _logger;
        private readonly CommentContainer _commentContainer;

        public CommentController(ILogger<CommentController> logger, DBSpeedrunsaverContext dbcontext)
        {
            CommentDAL commentDAL = new CommentDAL(dbcontext);
            _commentContainer = new CommentContainer(commentDAL);
            _logger = logger;
        }

        [HttpGet]
        [Route("/Comment/All")]
        public async Task<IActionResult> GetComments()
        {
            return Ok(await _commentContainer.GetComments());
        }

        [HttpGet]
        [Route("/Comment/Specific")]
        public async Task<IActionResult> GetComment(int id)
        {
            return Ok(await _commentContainer.GetComment(id));
        }

        [HttpPost]
        [Route("/Comment/Create")]
        public async Task<IActionResult> CreateComment([FromBody] CommentBody body)
        {
            try
            {
                await _commentContainer.CreateComment(body);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong when trying to create comment: " + e.Message);
            }
        }
    }
}
