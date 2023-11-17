using Interfaces.DB.DAL;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Mock
{
    public class GameMock: IGameDAL
    {
        public List<GameDTO> games = new List<GameDTO>()
        {
            new GameDTO() {
                Id = 1,
                GameName = "Game1",
                GameImage = "Image1",
                GameDescription = "Description1",
                Developer = "Developer1",
                Publisher = "Publisher1",
                ReleaseDate = DateTime.Now,
                Platforms = new List<PlatformDTO> { new PlatformDTO() {  Id = 1, Manufacturer = "Manu1", PlatformName = "platform1", ReleaseDate = DateTime.Now} }
            },
            new GameDTO(){ 
                Id = 2,
                GameName = "Game2",
                GameImage = "Image2",
                GameDescription = "Description2",
                Developer = "Developer2",
                Publisher = "Publisher1",
                ReleaseDate = DateTime.Now,
                Platforms = new List<PlatformDTO> { new PlatformDTO() {  Id = 1, Manufacturer = "Manu1", PlatformName = "platform1", ReleaseDate = DateTime.Now} }
            }
        };

        public async Task<List<GameDTO>> GetGames()
        {
            return await Task.FromResult(games);
        }

        public async Task<GameDTO> GetGame(int id)
        {
            return await Task.FromResult(games.FirstOrDefault(x => x.Id == id));
        }

        public async Task<GameDTO> GetGameByName(string name)
        {
            return await Task.FromResult(games.FirstOrDefault(x => x.GameName == name));
        }

        public async Task CreateGame(GameDTO gameDTO)
        {
            gameDTO.Id = games.Last().Id + 1;
            games.Add(gameDTO);
            await Task.CompletedTask;
        }

        public async Task UpdateGame(GameDTO gameDTO)
        {
            var game = games.FirstOrDefault(x => x.Id == gameDTO.Id);
            game.GameName = gameDTO.GameName;
            game.GameImage = gameDTO.GameImage;
            game.GameDescription = gameDTO.GameDescription;
            game.Developer = gameDTO.Developer;
            game.Publisher = gameDTO.Publisher;
            game.ReleaseDate = gameDTO.ReleaseDate;
            game.Platforms = gameDTO.Platforms;
            await Task.CompletedTask;
        }

        public async Task DeleteGame(int id)
        {
            var game = games.FirstOrDefault(x => x.Id == id);
            games.Remove(game);
            await Task.CompletedTask;
        }
    }
}
