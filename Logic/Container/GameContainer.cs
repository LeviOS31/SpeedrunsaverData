using Interfaces.DB;
using Interfaces.Models;
using Interfaces.RequestBody;
using Microsoft.EntityFrameworkCore;

namespace Logic.Container
{
    public class GameContainer
    {
        private readonly IDBContext _dbContext;

        public GameContainer(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Game>> GetGames()
        {
            return await _dbContext.Games.ToListAsync();
        }

        public async Task<Game> GetGame(int id)
        {
            Game game = await _dbContext.Games
                .Include(g => g.Platforms)
                .FirstOrDefaultAsync(g => g.Id == id);

            return game;
        }

        public async Task CreateGame(GameBody body)
        {
            Game game = new Game
            {
                GameName = body.GameName,
                GameDescription = body.GameDescription,
                GameImage = body.GameImage,
                Developer = body.Developer,
                Publisher = body.Publisher,
                ReleaseDate = body.ReleaseDate
            };

            await _dbContext.Games.AddAsync(game);
            await _dbContext.SaveChangesAsync();
        }
    }
}
