using System;
using System.Collections.Generic;
using System.Text;
using TCG_CollectionGame.Enities.Models;

namespace TCG_CollectionGame.Business.Interfaces
{
    public interface IBusinessUserService
    {
        public User GetUser(string username);
        public void UpdateUser(User user);
        public bool UserExists(string username);
        public void AddUser(User user);
        public bool CheckCoins(string username);
    }
}
