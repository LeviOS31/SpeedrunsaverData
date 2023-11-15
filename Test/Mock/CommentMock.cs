using Interfaces.DB.DAL;
using Interfaces.DTO;

namespace Test.Mock
{
    public class CommentMock: ICommentDAL
    {
        List<CommentDTO> comments = new List<CommentDTO>
        {
            new CommentDTO
            {
                Id = 1,
                CommentText = "Comment 1",
                UserId = 1,
                SpeedrunId = 1,
                Date = DateTime.Now
            },
            new CommentDTO
            {
                Id = 2,
                CommentText = "Comment 2",
                UserId = 2,
                SpeedrunId = 2,
                Date = DateTime.Now
            },
        };
        public async Task<List<CommentDTO>> GetComments()
        {
            return comments;
        }

        public async Task<CommentDTO> GetComment(int id)
        {
            return comments.FirstOrDefault(c => c.Id == id);
        }

        public async Task CreateComment(CommentDTO commentDTO)
        {
            commentDTO.Id = comments.Count + 1;
            comments.Add(commentDTO);
        }

        public async Task UpdateComment(CommentDTO commentDTO)
        {
            comments.Remove(comments.Find(x => x.Id == commentDTO.Id));
            comments.Add(commentDTO);
        }

        public async Task DeleteComment(int id)
        {
            comments.Remove(comments.Find(x => x.Id == id));
        }
    }

}
