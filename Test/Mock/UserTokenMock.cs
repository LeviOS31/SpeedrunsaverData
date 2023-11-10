using Interfaces.DB.DAL;
using Interfaces.DTO;

namespace Test.Mock
{
    public class UserTokenMock: IUserTokenDAL
    {
        public List<UserTokenDTO> Tokens = new List<UserTokenDTO>
        {
            new UserTokenDTO()
            {
                token = "aaa123213453",
                userId = 1,
            },
            new UserTokenDTO()
            {
                token = "dsdsf323243",
                userId = 2,
            }
        };

        public async Task<UserTokenDTO> CheckIfTokenExistsForUser(int userId)
        {
            return await Task.FromResult(Tokens.FirstOrDefault(x => x.userId == userId));
        }

        public async Task<UserTokenDTO> CheckIfTokenExists(string token)
        {
            return await Task.FromResult(Tokens.FirstOrDefault(x => x.token == token));
        }

        public async Task<UserTokenDTO> CreateUserToken(int userid)
        {
            string token = await TokenGenerator();
            UserTokenDTO userTokenDTO = new UserTokenDTO
            {
                token = token,
                userId = userid,
            };

            Tokens.Add(userTokenDTO);
            return userTokenDTO;
        }

        public async Task DeleteUserToken(string token)
        {
            UserTokenDTO userTokenDTO = await CheckIfTokenExists(token);
            Tokens.Remove(userTokenDTO);
        }

        private async Task<string> TokenGenerator()
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] result = new char[10];

            for (int i = 0; i < 10; i++)
            {
                result[i] = characters[random.Next(0, characters.Length)];
            }

            string token = new string(result);

            if (await CheckIfTokenExists(token) != null)
            {
                token = await TokenGenerator();
            }

            return token;
        }
    }
}
