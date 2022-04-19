using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Data.Interfaces
{
    public interface IUserService
    {
        User GetUser(string user);

        bool UserExists(string user);

        void AddUser(User user);

        void UpdateUser(User user);
    }
}