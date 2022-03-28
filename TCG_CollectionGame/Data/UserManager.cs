using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCG_CollectionGame.Data;

namespace TCG_CollectionGame.Models
{
    public class UserManager
    {
        private readonly TCG_CollectionGameContext _context;

        public UserManager(TCG_CollectionGameContext context)
        {
            _context = context;
        }

        public bool UserExists(string U)
        {
            return _context.User.Any(e => e.Username == U);
        }

        public void AddUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public User getUser(string user)
        {
            User u = _context.User.FirstOrDefault(e => e.Username == user);
            return u;
        }
    }
}
