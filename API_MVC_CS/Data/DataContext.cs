using Microsoft.EntityFrameworkCore;
using MVC_CS_API.Data.Entities;

namespace MVC_CS_API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> AppUsers { get; set; }
    }
}