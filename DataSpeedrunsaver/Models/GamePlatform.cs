namespace DataSpeedrunsaver.Models
{
    public class GamePlatform
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlatformId { get; set; }
        public Game Game { get; set; }
        public Platform Platform { get; set; }
    }
}
