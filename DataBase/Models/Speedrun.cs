using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Models
{
    public class Speedrun
    {
        public int Id { get; set; }
        public int rank { get; set; }
        public string SpeedrunName { get; set; }
        public string SpeedrunDescription { get; set; }
        public int categoryId { get; set; }
        public int platformId { get; set; }
        public int userId { get; set; }
        public DateTime time { get; set; }
        public DateTime Date { get; set; }
        public string VideoLink { get; set; }
        public int status { get; set; }
        [ForeignKey("categoryId")]
        public Category Category { get; set; }
        [ForeignKey("platformId")]
        public Platform Platform { get; set; }
        [ForeignKey("userId")]
        public User User { get; set; }
    }
}
