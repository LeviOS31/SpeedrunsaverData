using Interfaces.DB;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore;

namespace Logic.Container
{
    public class SpeedrunContainer
    {
        private readonly IDBContext _dbContext;

        public SpeedrunContainer(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Speedrun>> GetSpeedruns()
        {
            return await _dbContext.Runs.ToListAsync();
        }
    }
}
