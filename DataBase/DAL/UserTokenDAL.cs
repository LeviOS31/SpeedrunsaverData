using DataBase.Data;
using DataBase.Models;
using Interfaces.DB.DAL;
using Interfaces.DTO;
using Microsoft.EntityFrameworkCore;

namespace DataBase.DAL
{
    public class UserTokenDAL: IUserTokenDAL
    {
        private readonly DBSpeedrunsaverContext dbcontext;

        public UserTokenDAL(DBSpeedrunsaverContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public async Task<UserTokenDTO> CheckIfTokenExistsForUser(int userId)
        {
            UserTokens usertoken = await dbcontext.UserTokens.FirstOrDefaultAsync(x => x.userId == userId);
            if (usertoken == null)
            {
                return null;
            }
            DateTime yesterday = DateTime.Now.AddDays(-1);
            if (usertoken.datecreated <= yesterday)
            {
                await DeleteUserToken(usertoken.Token);
                return null;
            }
            return new UserTokenDTO
            {
                token = usertoken.Token,
                userId = usertoken.userId,
            };
        }

        public async Task<UserTokenDTO> CheckIfTokenExists(string token)
        {
            UserTokens usertoken = await dbcontext.UserTokens.FindAsync(token);
            if (usertoken == null)
            {
                return null;
            }
            DateTime yesterday = DateTime.Now.AddDays(-1);
            if (usertoken.datecreated <= yesterday)
            {
                DeleteUserToken(token);
                return null;
            }
            return new UserTokenDTO
            {
                token = usertoken.Token,
                userId = usertoken.userId,
            };
        }

        public async Task<UserTokenDTO> CreateUserToken(int userid)
        {
            string token = await TokenGenerator();
            UserTokens usertoken = new UserTokens
            {
                Token = token,
                userId = userid,
                datecreated = DateTime.Now,
            };
            dbcontext.UserTokens.Add(usertoken);
            await dbcontext.SaveChangesAsync();

            UserTokenDTO userTokenDTO = new UserTokenDTO
            {
                token = token,
                userId = userid,
            };
            return userTokenDTO;
        }

        public async Task DeleteUserToken(string token)
        {
            UserTokens usertoken = await dbcontext.UserTokens.FindAsync(token);
            dbcontext.UserTokens.Remove(usertoken);
            await dbcontext.SaveChangesAsync();
        }

        public async Task<string> TokenGenerator()
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] result = new char[10];

            for (int i = 0; i < 10; i++)
            {
                result[i] = characters[random.Next(0, characters.Length)];
            }

            string token = new string(result);

            if(await CheckIfTokenExists(token) != null)
            {
                token = await TokenGenerator();
            }

            return token;

        }
    }
}
