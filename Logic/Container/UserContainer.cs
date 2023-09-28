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
            
            string password = BCrypt.Net.BCrypt.HashPassword(body.Password);
            var user = new User
            {
                Username = body.Username,
                Password = password,
                Country = body.Country,
                Email = body.Email,
                Admin = body.Admin
            };
            await _dBContext.Users.AddAsync(user);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<int> ValidateUser(UserBody body) 
        {
            User user = await _dBContext.Users.FirstOrDefaultAsync(u => u.Username == body.Username);
            if(user != null) 
            {
                if (BCrypt.Net.BCrypt.Verify(body.Password, user.Password))
                {
                    return user.Id;
                }
            }
            return 0;
        }
    }
}
