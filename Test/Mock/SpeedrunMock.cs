using Interfaces.DB.DAL;
using Interfaces.DTO;

namespace Test.Mock
{
    public class SpeedrunMock: ISpeedrunDAL
    {
        List<SpeedrunDTO> speedruns = new List<SpeedrunDTO>
        {
            new SpeedrunDTO
            {
                Id = 1,
                rank = 1,
                SpeedrunName = "Test",
                SpeedrunDescription = "Testdesc",
                categoryId = 1,
                platformId = 1,
                userId = 1,
                time = new DateTime(1900,1,1,1,25,20,573),
                Date = DateTime.Now,
                VideoLink = "https://www.youtube.com/watch?v=5qap5aO4i9A",
                status = 1,
            },
            new SpeedrunDTO 
            {
                Id = 2,
                rank = 2,
                SpeedrunName = "Test2",
                SpeedrunDescription = "Testdesc2",
                categoryId = 1,
                platformId = 1,
                userId = 1,
                time = new DateTime(1900,1,1,1,35,20,573),
                Date = DateTime.Now,
                VideoLink = "https://www.youtube.com/watch?v=5qap5aO4i9A",
                status = 1,
            }
        };

        public async Task CreateSpeedrun(SpeedrunDTO speedrun)
        {
            speedrun.Id = speedruns.Count + 1;
            speedruns.Add(speedrun);
        }

        public async Task DeleteSpeedrun(int id)
        {
            speedruns.Remove(speedruns.Find(x => x.Id == id));
        }

        public async Task<SpeedrunDTO> GetSpeedrun(int id)
        {
            return speedruns.Find(x => x.Id == id);
        }

        public async Task<List<SpeedrunDTO>> GetSpeedruns()
        {
            return speedruns;
        }

        public async Task<List<SpeedrunDTO>> GetSpeedrunsByCategory(int id)
        {
            return speedruns.FindAll(x => x.categoryId == id);
        }

        public async Task UpdateSpeedrun(SpeedrunDTO speedrun)
        {
            speedruns.Remove(speedruns.Find(x => x.Id == speedrun.Id));
            speedruns.Add(speedrun);
        }
    
        public async Task<List<SpeedrunDTO>> GetLatestRuns()
        {
            return speedruns.Take(5).ToList();
        }
    }
}
