using System.ComponentModel.DataAnnotations.Schema;

namespace Interfaces.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int? SpeedrunId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("SpeedrunId")]
        public Speedrun Speedrun { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
