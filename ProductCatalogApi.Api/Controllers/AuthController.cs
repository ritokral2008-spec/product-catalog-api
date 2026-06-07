using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController: ControllerBase
{
    private readonly AuthService _auth;

    public AuthController(AuthService auth)
    {
        _auth = auth;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _auth.Register(request.Username, request.Password);
        return Ok("User created");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var token = await _auth.Login(request.Username, request.Password);

        Console.WriteLine(request.Username);
        Console.WriteLine(request.Password);

        if(token == null)
            return Unauthorized();

        return Ok(new { token });
    }
}