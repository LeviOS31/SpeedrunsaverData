namespace Interfaces.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int gameId { get; set; }
        public GameDTO Game { get; set; }
    }
}
