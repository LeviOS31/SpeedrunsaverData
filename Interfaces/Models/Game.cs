using System.ComponentModel.DataAnnotations.Schema;

namespace Interfaces.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string GameImage { get; set; }
        public string GameDescription { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Platform> Platforms { get; set; }
    }
}
