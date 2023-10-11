using DataBase.Data;
using DataBase.Models;
using Interfaces.DB.DAL;
using Interfaces.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DAL
{
    public class GameDAL: IGameDAL
    {
        private readonly DBSpeedrunsaverContext dbcontext;
        public GameDAL(DBSpeedrunsaverContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }
        public async Task<List<GameDTO>> GetGames()
        {
            List<Game> dbgames = await dbcontext.Games
                .Include(game => game.Platforms)
                .ToListAsync();
            List<GameDTO> games = new List<GameDTO>();
            foreach (Game game in dbgames)
            {
                games.Add(new GameDTO
                {
                    Id = game.Id,
                    GameName = game.GameName,
                    GameDescription = game.GameDescription,
                    GameImage = game.GameImage,
                    Developer = game.Developer,
                    Publisher = game.Publisher,
                    ReleaseDate = game.ReleaseDate,
                    Platforms = game.Platforms.Select(p => new PlatformDTO
                    {
                        Id = p.Id,
                        PlatformName = p.PlatformName,
                        ReleaseDate = p.ReleaseDate,
                        Manufacturer = p.Manufacturer,
                    }).ToList()
                });
            }
            return games;
        }

        public async Task<GameDTO> GetGame(int id)
        {
            Game game = await dbcontext.Games
                .Include(game => game.Platforms)
                .FirstOrDefaultAsync(game => game.Id == id);
            GameDTO gameDTO = new GameDTO
            {
                Id = game.Id,
                GameName = game.GameName,
                GameDescription = game.GameDescription,
                GameImage = game.GameImage,
                Developer = game.Developer,
                Publisher = game.Publisher,
                ReleaseDate = game.ReleaseDate,
                Platforms = game.Platforms.Select(p => new PlatformDTO
                {
                    Id = p.Id,
                    PlatformName = p.PlatformName,
                    ReleaseDate = p.ReleaseDate,
                    Manufacturer = p.Manufacturer,
                }).ToList()
            };

            return gameDTO;
        }

        public async Task CreateGame(GameDTO gameDTO)
        {
            List<Platform> platforms = new List<Platform>();
            foreach (var platform in gameDTO.Platforms)
            {
                platforms.Add(await dbcontext.Platforms.FindAsync(platform.Id));
            }

            Game game = new Game
            {
                GameName = gameDTO.GameName,
                GameDescription = gameDTO.GameDescription,
                GameImage = gameDTO.GameImage,
                Developer = gameDTO.Developer,
                Publisher = gameDTO.Publisher,
                ReleaseDate = gameDTO.ReleaseDate,
                Platforms = platforms
            };

            dbcontext.Games.Add(game);
            await dbcontext.SaveChangesAsync();
        }

        public async Task UpdateGame(GameDTO gameDTO)
        {
            List<Platform> platforms = new List<Platform>();
            foreach (var platform in gameDTO.Platforms)
            {
                platforms.Add(await dbcontext.Platforms.FindAsync(platform.Id));
            }

            var entryupdate = await dbcontext.Games.FindAsync(gameDTO.Id);

            entryupdate.GameName = gameDTO.GameName;
            entryupdate.GameDescription = gameDTO.GameDescription;
            entryupdate.GameImage = gameDTO.GameImage;
            entryupdate.Developer = gameDTO.Developer;
            entryupdate.Publisher = gameDTO.Publisher;
            entryupdate.ReleaseDate = gameDTO.ReleaseDate;
            entryupdate.Platforms = platforms;

            dbcontext.Games.Update(entryupdate);
            await dbcontext.SaveChangesAsync();
        }

        public async Task DeleteGame(int id)
        {
            Game game = await dbcontext.Games.FindAsync(id);
            dbcontext.Games.Remove(game);
            await dbcontext.SaveChangesAsync();
        }
    }
}
