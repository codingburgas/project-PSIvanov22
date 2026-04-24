using TheMissChat.Data;
using TheMissChat.Models;

namespace TheMissChat.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public User Register(string username, string password)
        {
            var user = new User
            {
                Username = username,
                Password = password
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User Login(string username, string password)
        {
            return _context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
