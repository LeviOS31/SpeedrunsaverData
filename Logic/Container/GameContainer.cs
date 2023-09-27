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
            return await _dbContext.Games.FindAsync(id);
        }

        public async Task AddGame(GameBody body)
        {
            Game game = new Game();

            game.GameName = body.GameName;
            game.GameDescription = body.GameDescription;
            game.Developer = body.Developer;
            game.Publisher = body.Publisher;
            game.ReleaseDate = body.ReleaseDate;

            await _dbContext.Games.AddAsync(game);
            await _dbContext.SaveChangesAsync();
        }
    }
}
