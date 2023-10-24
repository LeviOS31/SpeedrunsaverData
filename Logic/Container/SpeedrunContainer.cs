using Interfaces.DB.DAL;
using Interfaces.DTO;
using Interfaces.RequestBody;

namespace Logic.Container
{
    public class SpeedrunContainer
    {
        private readonly ISpeedrunDAL speedrunDAL;

        public SpeedrunContainer(ISpeedrunDAL _speedrunDAL)
        {
            speedrunDAL = _speedrunDAL;
        }

        public async Task<List<SpeedrunDTO>> GetSpeedruns()
        {
            return await speedrunDAL.GetSpeedruns();
        }

        public async Task<SpeedrunDTO> GetSpeedrun(int id)
        {
            return await speedrunDAL.GetSpeedrun(id);
        }

        public async Task<List<SpeedrunDTO>> GetSpeedrunsByCategory(int id)
        {
            return await speedrunDAL.GetSpeedrunsByCategory(id);
        }

        public async Task Createspeedrun(SpeedrunBody speedrunBody)
        {
            SpeedrunDTO speedrunDTO = new SpeedrunDTO
            {
                SpeedrunName = speedrunBody.SpeedrunName,
                SpeedrunDescription = speedrunBody.SpeedrunDescription,
                categoryId = speedrunBody.CategoryId,
                platformId = speedrunBody.PlatformId,
                userId = speedrunBody.UserId,
                time = speedrunBody.Time,
                Date = speedrunBody.Date,
                VideoLink = speedrunBody.VideoLink,
                status = speedrunBody.Status
            };

            await speedrunDAL.CreateSpeedrun(speedrunDTO);
        }

        public async Task Updatespeedrun(int id, SpeedrunBody speedrunbody)
        {
            SpeedrunDTO speedrunDTO = new SpeedrunDTO
            {
                Id = id,
                SpeedrunName = speedrunbody.SpeedrunName,
                SpeedrunDescription = speedrunbody.SpeedrunDescription,
                categoryId = speedrunbody.CategoryId,
                platformId = speedrunbody.PlatformId,
                userId = speedrunbody.UserId,
                time = speedrunbody.Time,
                Date = speedrunbody.Date,
                VideoLink = speedrunbody.VideoLink,
                status = speedrunbody.Status
            };
            await speedrunDAL.UpdateSpeedrun(speedrunDTO);
        }

        public async Task Deletespeedrun(int id)
        {
            await speedrunDAL.DeleteSpeedrun(id);
        }

        public async Task<List<SpeedrunDTO>> GetLatestRuns()
        {
            return await speedrunDAL.GetLatestRuns();
        }

    }
}
