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