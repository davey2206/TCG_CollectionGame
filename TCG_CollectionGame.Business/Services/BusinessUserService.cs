using System;
using System.Collections.Generic;
using System.Text;
using TCG_CollectionGame.Business.Interfaces;
using TCG_CollectionGame.Data.Interfaces;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Business.Services
{
    public class BusinessUserService : IBusinessUserService
    {
        private readonly IDataUserService _userService;
        public BusinessUserService(IDataUserService userService)
        {
            _userService = userService;
        }
        public User GetUser(string username)
        {
            return _userService.GetUser(username);
        }

        public void UpdateUser(User user)
        {
            _userService.UpdateUser(user);
        }

        public bool UserExists(string username)
        {
            return _userService.UserExists(username);
        }
        public void AddUser(User user)
        {
            _userService.AddUser(user);
        }
        public bool CheckCoins(string username)
        {
            User u = _userService.GetUser(username);

            if (u.Coin! >= 25)
            {
                return true;
            }
            return false;
        }

        public List<User> GetAllUsers(string username)
        {
            return _userService.GetAllUsers(username);
        }
    }
}
