using MVC_CS_API.Data.Entities;

namespace MVC_CS_API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            this._context = context;
        }

        public void DeleteUser(User user)
        {
            _context.AppUsers.Remove(user);
        }

        public List<User> GetUsers()
        {
            return _context.AppUsers.ToList();
        }

        public User GetUser(int id)
        {
            return _context.AppUsers.FirstOrDefault(x => x.Id == id);
        }

        public User GetUser(string username)
        {
            return _context.AppUsers.FirstOrDefault(x => x.Username == username);
        }

        public void InsertUser(User user)
        {
            _context.AppUsers.Add(user);
        }

        public bool IsSaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void UpdateUser(User user)
        {
            _context.AppUsers.Update(user);
        }
    }
}
