using Interfaces.DB;
using Interfaces.DB.DAL;
using Interfaces.DTO;
using Interfaces.RequestBody;

namespace Logic.Container
{
    public class PlatformContainer
    {
        private readonly IPlatformDAL platformDAL;

        public PlatformContainer(IPlatformDAL platformDAL)
        {
            this.platformDAL = platformDAL;
        }

        public async Task<List<PlatformDTO>> GetPlatforms()
        {
            return await platformDAL.GetPlatforms();
        }

        public async Task<PlatformDTO> GetPlatform(int id)
        {
            return await platformDAL.GetPlatform(id);
        }

        public async Task CreatePlatform(PlatformBody platformBody)
        {
            PlatformDTO platformDTO = new PlatformDTO
            {
                PlatformName = platformBody.PlatformName,
                ReleaseDate = platformBody.ReleaseDate,
                Manufacturer = platformBody.Manufacturer
            };

            await platformDAL.CreatePlatform(platformDTO);
        }

        public async Task UpdatePlatform(int id, PlatformBody platformBody)
        {
            PlatformDTO platformDTO = new PlatformDTO
            {
                Id = id,
                PlatformName = platformBody.PlatformName,
                ReleaseDate = platformBody.ReleaseDate,
                Manufacturer = platformBody.Manufacturer
            };

            await platformDAL.UpdatePlatform(platformDTO);
        }

        public async Task DeletePlatform(int id)
        {
            await platformDAL.DeletePlatform(id);
        }
    }
}
