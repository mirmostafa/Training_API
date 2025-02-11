using Microsoft.AspNetCore.Mvc;

namespace Session10.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Identity : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login(LoginModel model)
    {
        if (!this.ModelState.IsValid)
        {
            return this.BadRequest(this.ModelState);
        }
        return model.Username == "admin" && model.Password == "admin"
            ? this.Ok("Login successful")
            : this.BadRequest("Invalid username or password");
    }


    [HttpGet("login")]
    public IActionResult Login(string username, string password)
    {
        return this.Ok();
    }
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}