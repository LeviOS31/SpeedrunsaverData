using Interfaces.DB;
using Interfaces.Models;
using Interfaces.RequestBody;
using Microsoft.EntityFrameworkCore;

namespace Logic.Container
{
    public class UserContainer
    {
        private List<User> users { get; set; }
        private readonly IDBContext _dBContext;

        public UserContainer(IDBContext dBContext)
        {
            _dBContext = dBContext;
            users = _dBContext.Users.ToList();
        }

        public async Task<List<User>> GetUsers() 
        {
            return await _dBContext.Users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _dBContext.Users.FindAsync(id);
        }

        public async Task CreateUser(UserBody body) 
        {
            var user = new User
            {
                Username = body.Username,
                Password = body.Password,
                Country = body.Country,
                Email = body.Email,
                Admin = body.Admin
            };
            await _dBContext.Users.AddAsync(user);
            await _dBContext.SaveChangesAsync();
        }
    }
}
