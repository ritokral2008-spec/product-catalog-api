using ProductCatalogApi.Infrastructure.Data;

public static class DataSeeder
{
    public static void Seed(AppDbContext db)
    {
        if(!db.Roles.Any())
        {
            var adminRole = new Role { Name = "Admin" };
            var userRole = new Role { Name = "User" };

            db.Roles.AddRange(adminRole, userRole);
            db.SaveChanges();
        }
    }
}