namespace DataSpeedrunsaver.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public string PlatformName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Manufacturer { get; set; }
        public ICollection<GamePlatform> GamePlatforms { get; set; }
    }
}
