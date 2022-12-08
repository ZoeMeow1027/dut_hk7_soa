using MVC_CS_API.Data.Entities;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace MVC_CS_API.Data.Seed
{
    public static class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if (context.AppUsers.Any())
                return;

            var usersText = File.ReadAllText("Data/Seed/user.json");
            var data = JsonSerializer.Deserialize<List<Entities.User>>(usersText);

            data.ForEach(e => {
                using var hmac = new HMACSHA512();
                e.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("P@$$w0rd1"));
                e.PasswordSalt = hmac.Key;
                e.CreatedAt = DateTime.Now;
                context.AppUsers.Add(e);
            });

            context.SaveChanges();
        }
    }
}
