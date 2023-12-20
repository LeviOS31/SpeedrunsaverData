using DataBase.Data;
using DataBase.Models;
using Interfaces.DB.DAL;
using Interfaces.DTO;
using Microsoft.EntityFrameworkCore;

namespace DataBase.DAL
{
    public class UserDAL: IUserDAL
    {
        private readonly DBSpeedrunsaverContext dbcontext;
        public UserDAL(DBSpeedrunsaverContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public async Task<List<UserDTO>> GetUsers() 
        {
            List<User> dbusers = await dbcontext.Users.ToListAsync();
            List<UserDTO> users = new List<UserDTO>();
            foreach (User user in dbusers)
            {
                users.Add(new UserDTO
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password,
                    Country = user.Country,
                    Admin = user.Admin,
                });
            }
            return users;
        }

        public async Task<UserDTO> GetUser(int id)
        {
            User userdb = await dbcontext.Users.FindAsync(id);

            if (userdb == null)
            {
                return null;
            }
            UserDTO user = new UserDTO
            {
                Id = userdb.Id,
                Username = userdb.Username,
                Email = userdb.Email,
                Password = userdb.Password,
                Country = userdb.Country,
                Admin = userdb.Admin,
            };

            return user;
        }

        public async Task<UserDTO> GetUserByName(string name)
        {
            User userdb = await dbcontext.Users.FirstOrDefaultAsync(u => u.Username == name);
            if (userdb != null)
            {
                UserDTO user = new UserDTO
                {
                    Id = userdb.Id,
                    Username = userdb.Username,
                    Email = userdb.Email,
                    Password = userdb.Password,
                    Country = userdb.Country,
                    Admin = userdb.Admin,
                };
                return user;
            }
            return null;
        }

        public async Task CreateUser(UserDTO userDTO)
        {
            User user = new User
            {
                Username = userDTO.Username,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Country = userDTO.Country,
                Admin = userDTO.Admin,
            };
            dbcontext.Users.Add(user);
            await dbcontext.SaveChangesAsync();
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            var entryupdate = await dbcontext.Users.FindAsync(userDTO.Id);

            entryupdate.Username = userDTO.Username;
            entryupdate.Email = userDTO.Email;
            entryupdate.Password = userDTO.Password;
            entryupdate.Country = userDTO.Country;
            entryupdate.Admin = userDTO.Admin;

            dbcontext.Users.Update(entryupdate);
            await dbcontext.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var entrydelete = await dbcontext.Users.FindAsync(id);
            dbcontext.Users.Remove(entrydelete);
            await dbcontext.SaveChangesAsync();
        }
    }
}
