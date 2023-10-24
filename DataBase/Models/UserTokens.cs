using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Models
{
    public class UserTokens
    {
        [Key]
        public string Token { get; set; }
        public int userId { get; set; }
        public DateTime datecreated { get; set; }
        [ForeignKey("userId")]
        public User user { get; set; }
    }
}
