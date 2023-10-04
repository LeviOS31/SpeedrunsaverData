using Interfaces.DB;
using Interfaces.Models;
using Interfaces.RequestBody;
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

        public async Task<Speedrun> GetSpeedrun(int id)
        {
            return await _dbContext.Runs
                .Include(x => x.Category)
                .Include(x => x.User)
                .Include(x => x.Platform)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Speedrun>> GetSpeedrunsByCategory(int id)
        {
            return await _dbContext.Runs
                .Include(x => x.User)
                .Include(x => x.Platform)
                .Where(x => x.categoryId == id)
                .ToListAsync();
        }

        public async Task CreateSpeedrun(SpeedrunBody body) 
        {
            Speedrun speedrun = new Speedrun
            {
                SpeedrunName = body.SpeedrunName,
                SpeedrunDescription = body.SpeedrunDescription,
                categoryId = body.CategoryId,
                platformId = body.PlatformId,
                userId = body.UserId,
                time = body.Time,
                Date = body.Date,
                VideoLink = body.VideoLink,
                status = 0
            };

            await _dbContext.Runs.AddAsync(speedrun);
            await _dbContext.SaveChangesAsync();
        }
    }
}
