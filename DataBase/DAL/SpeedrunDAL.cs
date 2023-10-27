using DataBase.Data;
using DataBase.Models;
using Interfaces.DB.DAL;
using Interfaces.DTO;
using Microsoft.EntityFrameworkCore;

namespace DataBase.DAL
{
    public class SpeedrunDAL: ISpeedrunDAL
    {
        private readonly DBSpeedrunsaverContext dbcontext;
        public SpeedrunDAL(DBSpeedrunsaverContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public async Task<List<SpeedrunDTO>> GetSpeedruns()
        {
            List<Speedrun> dbspeedruns = await dbcontext.Runs
                .Include(s => s.Platform)
                .Include(s => s.User)
                .OrderBy(s => s.rank)
                .ToListAsync();
            List<SpeedrunDTO> speedruns = new List<SpeedrunDTO>();

            foreach(Speedrun speedrun in dbspeedruns)
            {
                speedruns.Add(new SpeedrunDTO
                {
                    Id = speedrun.Id,
                    rank = speedrun.rank,
                    SpeedrunName = speedrun.SpeedrunName,
                    SpeedrunDescription = speedrun.SpeedrunDescription,
                    categoryId = speedrun.categoryId,
                    platformId = speedrun.platformId,
                    userId = speedrun.userId,
                    time = speedrun.time,
                    Date = speedrun.Date,
                    VideoLink = speedrun.VideoLink,
                    status = speedrun.status,
                    Platform = new PlatformDTO
                    {
                        Id = speedrun.Platform.Id,
                        PlatformName = speedrun.Platform.PlatformName,
                    },
                    User = new UserDTO
                    {
                        Id = speedrun.User.Id,
                        Username = speedrun.User.Username,
                    }
                });
            }
            return speedruns;
        }

        public async Task<SpeedrunDTO> GetSpeedrun(int id)
        {
            Speedrun speedrun = await dbcontext.Runs
                .Include(s => s.User)
                .Include(s => s.Platform)
                .Include(s => s.Category)
                .ThenInclude(c => c.Game)
                .ThenInclude(g => g.Platforms)
                .FirstOrDefaultAsync(s => s.Id == id);
            if( speedrun != null)
            {
                List<PlatformDTO> platforms = new List<PlatformDTO>();

                foreach (Platform platform in speedrun.Category.Game.Platforms)
                {
                    platforms.Add(new PlatformDTO
                    {
                        Id = platform.Id,
                        PlatformName = platform.PlatformName,
                    });
                }

                SpeedrunDTO speedrunDTO = new SpeedrunDTO
                {
                    Id = speedrun.Id,
                    rank = speedrun.rank,
                    SpeedrunName = speedrun.SpeedrunName,
                    SpeedrunDescription = speedrun.SpeedrunDescription,
                    categoryId = speedrun.categoryId,
                    platformId = speedrun.platformId,
                    userId = speedrun.userId,
                    time = speedrun.time,
                    Date = speedrun.Date,
                    VideoLink = speedrun.VideoLink,
                    status = speedrun.status,
                    Category = new CategoryDTO
                    {
                        Id = speedrun.Category.Id,
                        CategoryName = speedrun.Category.CategoryName,
                        gameId = speedrun.Category.gameId,
                        Game = new GameDTO
                        {
                            Id = speedrun.Category.Game.Id,
                            GameName = speedrun.Category.Game.GameName,
                            GameDescription = speedrun.Category.Game.GameDescription,
                            Developer = speedrun.Category.Game.Developer,
                            Publisher = speedrun.Category.Game.Publisher,
                            ReleaseDate = speedrun.Category.Game.ReleaseDate,
                            Platforms = platforms,
                            GameImage = speedrun.Category.Game.GameImage,
                        }
                    },
                    Platform = new PlatformDTO
                    {
                        Id = speedrun.Platform.Id,
                        PlatformName = speedrun.Platform.PlatformName,
                        Manufacturer = speedrun.Platform.Manufacturer,
                    },
                    User = new UserDTO
                    {
                        Id = speedrun.User.Id,
                        Username = speedrun.User.Username,
                    }
                };
                return speedrunDTO;
            }
            return null;
        }

        public async Task<List<SpeedrunDTO>> GetSpeedrunsByCategory(int id)
        {
            List<Speedrun> speedruns = await dbcontext.Runs
                .Include(r => r.Category)
                .ThenInclude(c => c.Game)
                .Include(r => r.Platform)
                .Include(r => r.User)
                .OrderBy(s => s.rank)
                .Where(x => x.categoryId == id).ToListAsync();
            List<SpeedrunDTO> speedrunsDTO = new List<SpeedrunDTO>();

            foreach (Speedrun speedrun in speedruns)
            {
                speedrunsDTO.Add(new SpeedrunDTO
                {
                    Id = speedrun.Id,
                    rank = speedrun.rank,
                    SpeedrunName = speedrun.SpeedrunName,
                    SpeedrunDescription = speedrun.SpeedrunDescription,
                    categoryId = speedrun.categoryId,
                    platformId = speedrun.platformId,
                    userId = speedrun.userId,
                    time = speedrun.time,
                    Date = speedrun.Date,
                    VideoLink = speedrun.VideoLink,
                    status = speedrun.status,
                    Category = new CategoryDTO
                    {
                        Id = speedrun.Category.Id,
                        CategoryName = speedrun.Category.CategoryName,
                        gameId = speedrun.Category.gameId,
                        Game = new GameDTO
                        {
                            Id = speedrun.Category.Game.Id,
                            GameName = speedrun.Category.Game.GameName,
                            GameDescription = speedrun.Category.Game.GameDescription,
                            GameImage = speedrun.Category.Game.GameImage,
                        }
                    },
                    Platform = new PlatformDTO
                    {
                        Id = speedrun.Platform.Id,
                        PlatformName = speedrun.Platform.PlatformName,
                    },
                    User = new UserDTO
                    {
                        Id = speedrun.User.Id,
                        Username = speedrun.User.Username,
                    }
                });
            }

            return speedrunsDTO;
        }

        public async Task CreateSpeedrun(SpeedrunDTO speedrunDTO)
        {
            int rank = dbcontext.Runs.Count(s => s.time < speedrunDTO.time) + 1;
            Speedrun speedrun = new Speedrun
            {
                rank = rank,
                SpeedrunName = speedrunDTO.SpeedrunName,
                SpeedrunDescription = speedrunDTO.SpeedrunDescription,
                categoryId = speedrunDTO.categoryId,
                platformId = speedrunDTO.platformId,
                userId = speedrunDTO.userId,
                time = speedrunDTO.time,
                Date = speedrunDTO.Date,
                VideoLink = speedrunDTO.VideoLink,
                status = speedrunDTO.status,
            };
            dbcontext.Runs.Add(speedrun);
            await dbcontext.SaveChangesAsync();
        }

        public async Task UpdateSpeedrun(SpeedrunDTO speedrunDTO)
        {
            var entryupdate = await dbcontext.Runs.FindAsync(speedrunDTO.Id);

            entryupdate.SpeedrunName = speedrunDTO.SpeedrunName;
            entryupdate.SpeedrunDescription = speedrunDTO.SpeedrunDescription;
            entryupdate.categoryId = speedrunDTO.categoryId;
            entryupdate.platformId = speedrunDTO.platformId;
            entryupdate.userId = speedrunDTO.userId;
            entryupdate.time = speedrunDTO.time;
            entryupdate.Date = speedrunDTO.Date;
            entryupdate.VideoLink = speedrunDTO.VideoLink;
            entryupdate.status = speedrunDTO.status;

            dbcontext.Runs.Update(entryupdate);
            await dbcontext.SaveChangesAsync();
        }

        public async Task DeleteSpeedrun(int id)
        {
            Speedrun speedrun = await dbcontext.Runs.FindAsync(id);
            dbcontext.Runs.Remove(speedrun);
            await dbcontext.SaveChangesAsync();
        }

        public async Task<List<SpeedrunDTO>> GetLatestRuns()
        {
            List<Speedrun> dbspeedruns = await dbcontext.Runs
               .Include(s => s.Platform)
               .Include(s => s.User)
               .Include(s => s.Category)
               .ThenInclude(c => c.Game)
               .OrderBy(s => s.Date)
               .Where(s => s.status == 1)
               .ToListAsync();
            List<SpeedrunDTO> speedruns = new List<SpeedrunDTO>();

            foreach( Speedrun speedrun in dbspeedruns)
            {
                speedruns.Add(new SpeedrunDTO
                {
                    Id = speedrun.Id,
                    rank = speedrun.rank,
                    SpeedrunName = speedrun.SpeedrunName,
                    SpeedrunDescription = speedrun.SpeedrunDescription,
                    categoryId = speedrun.categoryId,
                    platformId = speedrun.platformId,
                    userId = speedrun.userId,
                    time = speedrun.time,
                    Date = speedrun.Date,
                    VideoLink = speedrun.VideoLink,
                    status = speedrun.status,
                    Platform = new PlatformDTO
                    {
                        Id = speedrun.Platform.Id,
                        PlatformName = speedrun.Platform.PlatformName,
                    },
                    User = new UserDTO
                    {
                        Id = speedrun.User.Id,
                        Username = speedrun.User.Username,
                    },
                    Category = new CategoryDTO
                    {
                        Id = speedrun.Category.Id,
                        CategoryName = speedrun.Category.CategoryName,
                        gameId = speedrun.Category.gameId,
                        Game = new GameDTO
                        {
                            Id = speedrun.Category.Game.Id,
                            GameName = speedrun.Category.Game.GameName,
                            GameDescription = speedrun.Category.Game.GameDescription,
                            GameImage = speedrun.Category.Game.GameImage,
                        }
                    },
                });
            }
            
            speedruns = speedruns.Take(5).ToList();
            return speedruns;
        }
    }
}
