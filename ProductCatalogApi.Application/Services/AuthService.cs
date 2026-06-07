using Microsoft.EntityFrameworkCore;
using ProductCatalogApi.Infrastructure.Data;
using BCrypt.Net;

public class AuthService
{
    private readonly AppDbContext _db;
    private readonly JwtService _jwt;

    public AuthService(AppDbContext db, JwtService jwt)
    {
        _db = db;
        _jwt = jwt;
    }

    public async Task Register(string username, string password)
    {
        // проверка на дубликат
        var exists = await _db.Users
            .AnyAsync(x => x.Username == username);

        if(exists)
            throw new Exception("User already exists");

        // получаем роль User из базы (НЕ хардкод)
        var userRole = await _db.Roles
            .FirstOrDefaultAsync(r => r.Name == "User");

        if(userRole == null)
            throw new Exception("Role 'User' not found");

        var user = new User
        {
            Username = username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            RoleId = userRole.Id
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();
    }

    public async Task<string?> Login(string username, string password)
    {
        try
        {
            var user = await _db.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Username == username);

            if(user == null)
                return null;

            var isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if(!isValid)
                return null;

            if(user.Role == null)
                throw new Exception("ROLE IS NULL");

            return _jwt.GenerateToken(user.Username, user.Role.Name);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }
}
