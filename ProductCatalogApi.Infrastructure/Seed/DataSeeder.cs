using ProductCatalogApi.Infrastructure.Data;

public static class DataSeeder
{
    public static void Seed(AppDbContext db)
    {
        if(!db.Roles.Any())
        {
            db.Roles.AddRange(
                new Role { Name = "Admin" },
                new Role { Name = "User" }
            );

            db.SaveChanges();
        }
    if(!db.Users.Any(u => u.Username == "admin"))
        {
            var adminRole = db.Roles.First(r => r.Name == "Admin");

            db.Users.Add(new User
            {
                Username = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                RoleId = adminRole.Id
            });
        }
    }
}