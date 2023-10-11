using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DB.DAL
{
    public interface IUserDAL
    {
        public Task<List<UserDTO>> GetUsers();
        public Task<UserDTO> GetUser(int id);
        public Task<UserDTO> GetUserByName(string name);
        public Task CreateUser(UserDTO userDTO);
        public Task UpdateUser(UserDTO userDTO);
        public Task DeleteUser(int id);
    }
}
