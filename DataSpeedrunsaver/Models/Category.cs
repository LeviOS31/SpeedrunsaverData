using System.ComponentModel.DataAnnotations.Schema;

namespace DataSpeedrunsaver.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int gameId { get; set; }
        [ForeignKey("gameId")]
        public Game Game { get; set; }
    }
}
