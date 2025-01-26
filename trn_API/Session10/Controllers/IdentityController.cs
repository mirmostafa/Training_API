using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using Session10.Application.Services;

namespace Session10.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController: ControllerBase
{
    private readonly JwtService _jwtService;

    public IdentityController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // شبیه‌سازی تأیید اعتبار کاربر
        if (request.Username == "test" && request.Password == "password")
        {
            var token = _jwtService.GenerateJwtToken(request.Username);
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
}

public class LoginRequest
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}
