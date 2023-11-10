using Interfaces.DB.DAL;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Mock
{
    public class UserMock: IUserDAL
    {
        public List<UserDTO> Users = new List<UserDTO>()
        {
            new UserDTO() { Id = 1, Username = "User1", Password = BCrypt.Net.BCrypt.HashPassword("Password1"), Email = "Email1", Admin = true },
            new UserDTO() { Id = 2, Username = "User2", Password = BCrypt.Net.BCrypt.HashPassword("Password2"), Email = "Email2", Admin = false }
        };

        public async Task<List<UserDTO>> GetUsers()
        {
            return await Task.FromResult(Users);
        }

        public async Task<UserDTO> GetUser(int id)
        {
            return await Task.FromResult(Users.FirstOrDefault(x => x.Id == id));
        }

        public async Task<UserDTO> GetUserByName(string name)
        {
            return await Task.FromResult(Users.FirstOrDefault(x => x.Username == name));
        }

        public async Task CreateUser(UserDTO userDTO)
        {
            userDTO.Id = Users.Last().Id + 1;
            Users.Add(userDTO);
            await Task.CompletedTask;
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            UserDTO user = Users.FirstOrDefault(x => x.Id == userDTO.Id);
            user.Username = userDTO.Username;
            user.Password = userDTO.Password;
            user.Email = userDTO.Email;
            user.Admin = userDTO.Admin;
            await Task.CompletedTask;
        }

        public async Task DeleteUser(int id)
        {
            UserDTO user = Users.FirstOrDefault(x => x.Id == id);
            Users.Remove(user);
            await Task.CompletedTask;
        }
    }
}
