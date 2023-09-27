using Interfaces.DB;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
