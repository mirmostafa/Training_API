using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using Session11.Application.Services;

namespace Session11.Controllers;

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
            return this.Ok(new { Token = token });
        }
        //return new StatusCodeResult((int)HttpStatusCode.SeeOther);
        return this.Unauthorized();
    }
}


public class LoginRequest
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}
