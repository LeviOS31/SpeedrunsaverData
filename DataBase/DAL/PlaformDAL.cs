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
    public class PlaformDAL: IPlatformDAL
    {
        private readonly DBSpeedrunsaverContext dbcontext;
        public PlaformDAL(DBSpeedrunsaverContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public async Task<List<PlatformDTO>> GetPlatforms()
        {
            List<Platform> dbplatforms = await dbcontext.Platforms.ToListAsync();
            List<PlatformDTO> platforms = new List<PlatformDTO>();

            foreach (Platform platform in dbplatforms)
            {
                platforms.Add(new PlatformDTO
                {
                    Id = platform.Id,
                    PlatformName = platform.PlatformName,
                    ReleaseDate = platform.ReleaseDate,
                    Manufacturer = platform.Manufacturer,
                });
            }
            return platforms;
        }
        public async Task<PlatformDTO> GetPlatform(int id)
        {
            Platform platform = await dbcontext.Platforms.FindAsync(id);
            PlatformDTO platformDTO = new PlatformDTO
            {
                Id = platform.Id,
                PlatformName = platform.PlatformName,
                ReleaseDate = platform.ReleaseDate,
                Manufacturer = platform.Manufacturer,
            };
            return platformDTO; 
        }
        public async Task CreatePlatform(PlatformDTO platformDTO)
        {
            List<Game> games = new List<Game>();
            foreach (GameDTO game in platformDTO.Games)
            {
                games.Add(await dbcontext.Games.FindAsync(game.Id));
            }

            Platform platform = new Platform
            {
                PlatformName = platformDTO.PlatformName,
                ReleaseDate = platformDTO.ReleaseDate,
                Manufacturer = platformDTO.Manufacturer,
                Games = games
            };

            dbcontext.Platforms.Add(platform);
            await dbcontext.SaveChangesAsync();
        }
        public async Task UpdatePlatform(PlatformDTO platformDTO)
        {
            List<Game> games = new List<Game>();
            foreach (GameDTO game in platformDTO.Games)
            {
                games.Add(await dbcontext.Games.FindAsync(game.Id));
            }

            var entryupdate = await dbcontext.Platforms.FindAsync(platformDTO.Id);

            entryupdate.PlatformName = platformDTO.PlatformName;
            entryupdate.ReleaseDate = platformDTO.ReleaseDate;
            entryupdate.Manufacturer = platformDTO.Manufacturer;
            entryupdate.Games = games;

            dbcontext.Platforms.Update(entryupdate);
            await dbcontext.SaveChangesAsync();
        }
        public async Task DeletePlatform(int id)
        {
            Platform platform = await dbcontext.Platforms.FindAsync(id);
            dbcontext.Platforms.Remove(platform);
            await dbcontext.SaveChangesAsync();
        }
    }
}
