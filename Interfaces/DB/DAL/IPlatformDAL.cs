using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DB.DAL
{
    public interface IPlatformDAL
    {
        public Task<List<PlatformDTO>> GetPlatforms();
        public Task<PlatformDTO> GetPlatform(int id);
        public Task CreatePlatform(PlatformDTO platformDTO);
        public Task UpdatePlatform(PlatformDTO platformDTO);
        public Task DeletePlatform(int id);

    }
}
