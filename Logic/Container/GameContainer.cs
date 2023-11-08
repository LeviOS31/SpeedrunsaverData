using Interfaces.DB;
using Interfaces.DB.DAL;
using Interfaces.DTO;
using Interfaces.RequestBody;

namespace Logic.Container
{
    public class GameContainer
    {
        private readonly IGameDAL gameDAL;

        public GameContainer(IGameDAL gameDAL)
        {
            this.gameDAL = gameDAL;
        }

        public async Task<List<GameDTO>> GetGames()
        {
            return await gameDAL.GetGames();
        }

        public async Task<GameDTO> GetGame(int id)
        {
            return await gameDAL.GetGame(id);
        }

        public async Task<GameDTO> GetGameByName(string name)
        {
            return await gameDAL.GetGameByName(name);
        }

        public async Task CreateGame(GameBody gamebody)
        {
            GameDTO gameDTO = new GameDTO
            {
                GameName = gamebody.GameName,
                GameImage = gamebody.GameImage,
                GameDescription = gamebody.GameDescription,
                Developer = gamebody.Developer,
                Publisher = gamebody.Publisher,
                ReleaseDate = gamebody.ReleaseDate,
                Platforms = gamebody.Platforms
            };

            await gameDAL.CreateGame(gameDTO);
        }

        public async Task UpdateGame(int id, GameBody gamebody)
        {
            GameDTO gameDTO = new GameDTO
            {
                Id = id,
                GameName = gamebody.GameName,
                GameImage = gamebody.GameImage,
                GameDescription = gamebody.GameDescription,
                Developer = gamebody.Developer,
                Publisher = gamebody.Publisher,
                ReleaseDate = gamebody.ReleaseDate,
                Platforms = gamebody.Platforms
            };

            await gameDAL.UpdateGame(gameDTO);
        }

        public async Task DeleteGame(int id)
        {
            await gameDAL.DeleteGame(id);
        }
    }
}
