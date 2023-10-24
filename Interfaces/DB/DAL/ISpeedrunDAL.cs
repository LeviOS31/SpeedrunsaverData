using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DB.DAL
{
    public interface ISpeedrunDAL
    {
        public Task<List<SpeedrunDTO>> GetSpeedruns();
        public Task<SpeedrunDTO> GetSpeedrun(int id);
        public Task CreateSpeedrun(SpeedrunDTO speedrunDTO);
        public Task<List<SpeedrunDTO>> GetSpeedrunsByCategory(int id);
        public Task UpdateSpeedrun(SpeedrunDTO speedrunDTO);
        public Task DeleteSpeedrun(int id);
        public Task<List<SpeedrunDTO>> GetLatestRuns();
    }
}
