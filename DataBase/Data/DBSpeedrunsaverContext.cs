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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=mssqlstud.fhict.local;Database=dbi512680_speedrun;User Id=dbi512680_speedrun;Password=Admin1234;TrustServerCertificate=True;"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>()
                .HasMany(p => p.Games)
                .WithMany(g => g.Platforms);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
