using DataBase.Data;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebsocketttestAPI.Controllers;

namespace WebsocketsSpeedrunsavers.DBWatchers;
public class Databasewatcher
{
    private readonly DBSpeedrunsaverContext _context;
    private List<User> users = new List<User>();
    private List<Speedrun> runs = new List<Speedrun>();
    private List<Rule> rules = new List<Rule>();
    private List<Platform> platforms = new List<Platform>();
    private List<Game> games = new List<Game>();
    private List<Comment> comments = new List<Comment>();
    private List<Category> categories = new List<Category>();

    public Databasewatcher(DBSpeedrunsaverContext context)
    {
        _context = context;
    }

    public void StartWatching()
    {
        using (_context)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            users = _context.Users.ToList();
            runs = _context.Runs.ToList();
            rules = _context.Rules.ToList();
            platforms = _context.Platforms.ToList();
            games = _context.Games.ToList();
            comments = _context.Comments.ToList();
            categories = _context.Categories.ToList();

            stopwatch.Stop();
            Console.WriteLine($"Time to load all data: {stopwatch.ElapsedMilliseconds}ms");

            while (true)
            {
                CheckForChanges(_context);
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }

    private void CheckForChanges(DBSpeedrunsaverContext context)
    {
        var changes = context.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
        if (changes.Count > 0)
        {
            Console.WriteLine("Changes detected!");
            foreach (var change in changes)
            {
                Console.WriteLine($"Entity {change.Entity.GetType().Name} has changed from {change.OriginalValues} to {change.CurrentValues}");
            }

            // Notify connected clients about the changes
            WebsocketController.SendToAll("Database changes detected!");
        }
        else
        {
            Console.WriteLine("No changes detected!");
        }
    }
}
