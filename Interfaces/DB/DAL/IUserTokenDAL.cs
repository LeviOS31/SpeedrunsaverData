using Interfaces.DTO;

namespace Interfaces.DB.DAL
{
    public interface IUserTokenDAL
    {
        public Task<UserTokenDTO> CheckIfTokenExistsForUser(int userid);
        public Task<UserTokenDTO> CheckIfTokenExists(string token);
        public Task<UserTokenDTO> CreateUserToken(int userid);
        public Task DeleteUserToken(string token);
    }
}
