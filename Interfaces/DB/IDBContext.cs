namespace Interfaces.DB
{
    public interface IDBContext
    {
/*        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Speedrun> Runs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }*/
        Task<int> SaveChangesAsync();
    }
}
