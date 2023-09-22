using System.ComponentModel.DataAnnotations.Schema;

namespace DataSpeedrunsaver.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<GamePlatform> GamePlatforms { get; set; }
    }
}
