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
        private readonly IUserTokenDAL tokenDAL;

        public UserContainer(IUserDAL dal, IUserTokenDAL tokenDAL)
        {
            userDAL = dal;
            this.tokenDAL = tokenDAL;
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

        public async Task<UserTokenDTO> ValidateUser(UserBody body) 
        {
            UserDTO user = await userDAL.GetUserByName(body.Username);
            if(user != null) 
            {
                if (BCrypt.Net.BCrypt.Verify(body.Password, user.Password))
                {
                    UserTokenDTO token = await tokenDAL.CheckIfTokenExistsForUser(user.Id);
                    if (token == null)
                    {
                        return await tokenDAL.CreateUserToken(user.Id);
                    }
                    else
                    {
                        return token;
                    }
                }
            }
            return null;
        }

        public async Task<int> CheckifCorrect(TokenBody body)
        {
            UserTokenDTO token = await tokenDAL.CheckIfTokenExists(body.Token);
            if (token != null)
            {  
                if (body.userID == token.userId)
                {
                    UserDTO user = await userDAL.GetUser(token.userId);
                    if (body.AccesForAdmin)
                    {
                        if (user.Admin)
                        {
                            return user.Id;
                        }
                    }
                    else
                    {
                        return user.Id;
                    }
                }
            }
            return -1;
        }
    }
}
