using Interfaces.DB;
using Interfaces.DB.DAL;
using Interfaces.DTO;
using Interfaces.RequestBody;
using Microsoft.EntityFrameworkCore;

namespace Logic.Container
{
    public class UserContainer
    {
        private readonly IUserDAL userDAL;

        public UserContainer(IUserDAL dal)
        {
            userDAL = dal;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            return await userDAL.GetUsers();
        }

        public async Task<UserDTO> GetUser(int id)
        {
            return await userDAL.GetUser(id);
        }

        public async Task CreateUser(UserBody userBody)
        {
            UserDTO userDTO = new UserDTO
            {
                Username = userBody.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(userBody.Password),
                Country = userBody.Country,
                Email = userBody.Email,
                Admin = userBody.Admin
            };
            await userDAL.CreateUser(userDTO);
        }

        public async Task UpdateUser(int id, UserBody userBody)
        {
            UserDTO userDTO = new UserDTO
            {
                Id = id,
                Username = userBody.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(userBody.Password),
                Country = userBody.Country,
                Email = userBody.Email,
                Admin = userBody.Admin
            };
            await userDAL.UpdateUser(userDTO);
        }

        public async Task DeleteUser(int id)
        {
            await userDAL.DeleteUser(id);
        }

        public async Task<int> ValidateUser(UserBody body) 
        {
            UserDTO user = await userDAL.GetUserByName(body.Username);
            if(user != null) 
            {
                if (BCrypt.Net.BCrypt.Verify(body.Password, user.Password))
                {
                    return user.Id;
                }
            }
            return 0;
        }

        public async Task<int> CheckifCorrect(UserBody body)
        {
            UserDTO user = await userDAL.GetUser(body.Id);
            if(user.Username == body.Username)
            {
                if(user.Admin == body.Admin)
                {
                    return body.Id;
                }
            }
            return 0;
        }
    }
}
