using System.Collections.Generic;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Data.Interfaces
{
    public interface IDataUserService
    {
        User GetUser(string user);

        bool UserExists(string user);

        void AddUser(User user);

        void UpdateUser(User user);
        List<User> GetAllUsers(string username);
    }
}