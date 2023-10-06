namespace DataBase.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public string PlatformName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Manufacturer { get; set; }
        public List<Game> Games { get; set; }
    }
}
