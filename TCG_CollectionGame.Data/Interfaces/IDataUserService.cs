using TCG_CollectionGame.Enities.Models;

namespace TCG_CollectionGame.Data.Interfaces
{
    public interface IDataUserService
    {
        User GetUser(string user);

        bool UserExists(string user);

        void AddUser(User user);

        void UpdateUser(User user);
    }
}