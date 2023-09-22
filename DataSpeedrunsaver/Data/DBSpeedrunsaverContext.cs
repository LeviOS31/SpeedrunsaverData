using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DataSpeedrunsaver.Models;

namespace DataSpeedrunsaver.Data
{
    public class DBSpeedrunsaverContext: DbContext
    {
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Speedrun> Runs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=mssqlstud.fhict.local;Database=dbi512680_speedrun;User Id=dbi512680_speedrun;Password=Admin1234;TrustServerCertificate=True;"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamePlatform>()
                .HasKey(gp => new { gp.GameId, gp.PlatformId });
            modelBuilder.Entity<GamePlatform>()
                .HasOne(gp => gp.Game)
                .WithMany(g => g.GamePlatforms)
                .HasForeignKey(gp => gp.GameId);
            modelBuilder.Entity<GamePlatform>()
                .HasOne(gp => gp.Platform)
                .WithMany(p => p.GamePlatforms)
                .HasForeignKey(gp => gp.PlatformId);
        }
    }
}
