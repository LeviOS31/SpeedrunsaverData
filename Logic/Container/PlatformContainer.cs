using Interfaces.DB;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Interfaces.RequestBody;

namespace Logic.Container
{
    public class PlatformContainer
    {
        private readonly IDBContext _dbContext;

        public PlatformContainer(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Platform>> GetPlatforms()
        {
            return await _dbContext.Platforms.ToListAsync();
        }

        public async Task<Platform> GetPlatform(int id)
        {
            return await _dbContext.Platforms.FindAsync(id);
        }

        public async Task CreatePlatform(PlatformBody body) 
        {
            Platform platform = new Platform
            {
                PlatformName = body.PlatformName,
                ReleaseDate = body.ReleaseDate,
                Manufacturer = body.Manufacturer
            };

            await _dbContext.Platforms.AddAsync(platform);
            await _dbContext.SaveChangesAsync();
        }
    }
}
