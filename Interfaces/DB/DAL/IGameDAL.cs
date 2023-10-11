using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DB.DAL
{
    public interface IGameDAL
    {
        public Task<List<GameDTO>> GetGames();
        public Task<GameDTO> GetGame(int id);
        public Task CreateGame(GameDTO gameBody);
        public Task UpdateGame(GameDTO gameBody);
        public Task DeleteGame(int id);
    }
}
