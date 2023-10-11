using Interfaces.DB.DAL;
using Interfaces.DTO;
using Interfaces.RequestBody;

namespace Logic.Container
{
    public class CommentContainer
    {
        private readonly ICommentDAL commentDAL;

        public CommentContainer(ICommentDAL commentDAL)
        {
            this.commentDAL = commentDAL;
        }

        public async Task<List<CommentDTO>> GetComments()
        {
            return await commentDAL.GetComments();
        }

        public async Task<CommentDTO> GetComment(int id)
        {
            return await commentDAL.GetComment(id);
        }

        public async Task CreateComment(CommentBody commentBody)
        {
            CommentDTO commentDTO = new CommentDTO
            {
                CommentText = commentBody.CommentText,
                Date = commentBody.Date,
                UserId = commentBody.UserId,
                SpeedrunId = commentBody.SpeedrunId
            };

            await commentDAL.CreateComment(commentDTO);
        }

        public async Task UpdateComment(int id, CommentBody commentBody)
        {
            CommentDTO commentDTO = new CommentDTO
            {
                Id = id,
                CommentText = commentBody.CommentText,
                Date = commentBody.Date,
                UserId = commentBody.UserId,
                SpeedrunId = commentBody.SpeedrunId
            };

            await commentDAL.UpdateComment(commentDTO);
        }

        public async Task DeleteComment(int id)
        {
            await commentDAL.DeleteComment(id);
        }
    }
}
