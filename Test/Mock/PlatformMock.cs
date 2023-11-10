using Interfaces.DB.DAL;
using Interfaces.DTO;

namespace Test.Mock
{
    public class PlatformMock: IPlatformDAL
    {
        List<PlatformDTO> platforms = new List<PlatformDTO>
        {
            new PlatformDTO { Id = 1, PlatformName = "Platform 1" },
            new PlatformDTO { Id = 2, PlatformName = "Platform 2" },
            new PlatformDTO { Id = 3, PlatformName = "Platform 3" },
        };

        public async Task<List<PlatformDTO>> GetPlatforms()
        {
            return platforms;
        }

        public async Task<PlatformDTO> GetPlatform(int id)
        {
            return platforms.FirstOrDefault(p => p.Id == id);
        }

        public async Task CreatePlatform(PlatformDTO platformDTO)
        {
            platforms.Add(platformDTO);
        }

        public async Task UpdatePlatform(PlatformDTO platformDTO)
        {
            platforms.Remove(platforms.Find(x => x.Id == platformDTO.Id));
            platforms.Add(platformDTO);
        }

        public async Task DeletePlatform(int id)
        {
            platforms.Remove(platforms.Find(x => x.Id == id));
        }
    }
}
