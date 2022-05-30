using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TCG_CollectionGame.Data.Interfaces;
using TCG_CollectionGame.DataContext;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Data.Services
{
    public class DataUserService : IDataUserService
    {
        private readonly TCG_CollectionGameContext _context;

        public DataUserService(TCG_CollectionGameContext context)
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

        public User GetUser(string username)
        {
            _context.Pokecard.Load();
            User u = _context.User.FirstOrDefault(e => e.Username == username);
            return u;
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers(string username)
        {
            List<User> users = _context.User.FromSqlRaw("SELECT * FROM [User]").ToList();
            users.RemoveAll(u => u.Username == username);
            return users;
        }
    }
}