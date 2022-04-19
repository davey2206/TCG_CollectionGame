using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCG_CollectionGame.Data.Interfaces;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Data.Services
{
    public class UserService : IUserService
    {
        private readonly TCG_CollectionGameContext _context;

        public UserService(TCG_CollectionGameContext context)
        {
            _context = context;
        }

        public bool UserExists(string user)
        {
            return _context.User.Any(e => e.Username == user);
        }

        public void AddUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public User GetUser(string user)
        {
            User u = _context.User.FirstOrDefault(e => e.Username == user);
            return u;
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}