using Microsoft.EntityFrameworkCore;
using DataBase.Models;

namespace DataBase.Data
{
    public class DBSpeedrunsaverContext: DbContext
    {
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Speedrun> Runs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTokens> UserTokens { get; set; }

        public DBSpeedrunsaverContext(DbContextOptions<DBSpeedrunsaverContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>()
                .HasMany(p => p.Games)
                .WithMany(g => g.Platforms);
        }

        public async Task<int> SaveChangesAsync()
        {
            // Calculate ranks only if a Speedrun entity has been added or its CompletionTime has changed
            await CalculateRanks();
            return await base.SaveChangesAsync();
        }

        private async Task CalculateRanks()
        {
            var entries = ChangeTracker.Entries<Speedrun>();
            var addedOrModifiedSpeedruns = entries.Where(e =>
                e.State == EntityState.Added || e.State == EntityState.Modified
            ).Select(e => e.Entity);

            if (addedOrModifiedSpeedruns.Any())
            {
                var categories = await Categories.ToListAsync();
                foreach(Category category in categories)
                {
                    var speedruns = await Runs.OrderBy(s => s.time).Where(s => s.categoryId == category.Id).ToListAsync();
                    int rank = 1;
                    foreach (var speedrun in speedruns)
                    {
                        speedrun.rank = rank++;
                    }
                }
            }
        }
    }
}
