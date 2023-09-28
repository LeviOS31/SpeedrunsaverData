using Interfaces.DB;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using Interfaces.RequestBody;

namespace Logic.Container
{
    public class CommentContainer
    {
        private readonly IDBContext _dbContext;

        public CommentContainer(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Comment>> GetComments()
        {
            return await _dbContext.Comments.ToListAsync();
        }

        public async Task<Comment> GetComment(int id)
        {
            return await _dbContext.Comments.FindAsync(id);
        }

        public async Task CreateComment(CommentBody body)
        {
            Comment comment = new Comment
            {
                CommentText = body.CommentText,
                UserId = body.UserId,
                SpeedrunId = body.SpeedrunId,
                Date = body.Date
            };

            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
