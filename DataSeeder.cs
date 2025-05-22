using Delivery.Models;
using Delivery.Data;
using Microsoft.AspNetCore.Identity; 
using System.Linq;

public static class DataSeeder
{
    public static void SeedAdminUser(AppDbContext context)
    {
        if (context.Users.Any(u => u.Role == "SystemAdmin"))
            return;

        var hasher = new PasswordHasher<User>();
        var adminUser = new User
        {
            Username = "admin",
            Role = "SystemAdmin"
        };
        adminUser.PasswordHash = hasher.HashPassword(adminUser, "adminpassword");

        context.Users.Add(adminUser);
        context.SaveChanges();
    }
}
