using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int? SpeedrunId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public SpeedrunDTO Speedrun { get; set; }
        public UserDTO User { get; set; }
    }
}
