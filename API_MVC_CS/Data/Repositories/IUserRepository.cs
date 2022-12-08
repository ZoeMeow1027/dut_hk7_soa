using MVC_CS_API.Data.Entities;

namespace MVC_CS_API.Data.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();

        User GetUser(int id);

        User GetUser(string username);

        void InsertUser(User user);

        void UpdateUser(User user);

        void DeleteUser(User user);

        bool IsSaveChanges();
    }
}
