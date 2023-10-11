using DataBase.Data;
using DataBase.Models;
using Interfaces.DB.DAL;
using Interfaces.DTO;
using Interfaces.RequestBody;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DAL
{
    public class CommentDAL: ICommentDAL
    {
        private readonly DBSpeedrunsaverContext _dbContext;

        public CommentDAL(DBSpeedrunsaverContext _dbcontext)
        {
            _dbContext = _dbcontext;
        }
        public async Task<List<CommentDTO>> GetComments()
        {
            List<Comment> dbcomments = await _dbContext.Comments.ToListAsync();
            List<CommentDTO> comments = new List<CommentDTO>();
            foreach (Comment comment in dbcomments)
            {
                comments.Add(new CommentDTO
                {
                    Id = comment.Id,
                    CommentText = comment.CommentText,
                    UserId = comment.UserId,
                    SpeedrunId = comment.SpeedrunId,
                    Date = comment.Date
                });
            }
            return comments;
        }

        public async Task<CommentDTO> GetComment(int id)
        {
            Comment comment = await _dbContext.Comments.FindAsync(id);
            CommentDTO commentDTO = new CommentDTO
            {
                Id = comment.Id,
                CommentText = comment.CommentText,
                UserId = comment.UserId,
                SpeedrunId = comment.SpeedrunId,
                Date = comment.Date
            };
            return commentDTO;
        }

        public async Task CreateComment(CommentDTO body)
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
        
        public async Task UpdateComment(CommentDTO commentDTO)
        {
            var entryupdate = await _dbContext.Comments.FindAsync(commentDTO.Id);

            entryupdate.CommentText = commentDTO.CommentText;
            entryupdate.UserId = commentDTO.UserId;
            entryupdate.SpeedrunId = commentDTO.SpeedrunId;
            entryupdate.Date = commentDTO.Date;

            _dbContext.Comments.Update(entryupdate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteComment(int id)
        {
            Comment comment = await _dbContext.Comments.FindAsync(id);
            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
