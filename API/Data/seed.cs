using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var Users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            foreach (var user in Users)
            {
                using var hmac = new HMACSHA512();
                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password"));
                user.PasswordSalt = hmac.Key;
                context.Users.Add(user);


            }
        }
    }
}