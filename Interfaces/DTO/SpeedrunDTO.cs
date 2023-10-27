
namespace Interfaces.DTO
{
    public class SpeedrunDTO
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
        public CategoryDTO Category { get; set; }
        public PlatformDTO Platform { get; set; }
        public UserDTO User { get; set; }
    }
}
