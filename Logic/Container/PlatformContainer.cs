using Interfaces.DB;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
