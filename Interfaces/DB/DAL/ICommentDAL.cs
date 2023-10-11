using Interfaces.DTO;

namespace Interfaces.DB.DAL
{
    public interface ICommentDAL
    {
        public Task<List<CommentDTO>> GetComments();
        public Task<CommentDTO> GetComment(int id);
        public Task CreateComment(CommentDTO body);
        public Task UpdateComment(CommentDTO body);
        public Task DeleteComment(int id);
    }
}
