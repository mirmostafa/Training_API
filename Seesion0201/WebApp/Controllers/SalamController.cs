using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("Bye")]
public class SalamController : ControllerBase
{
    [HttpGet]
    public IActionResult HowAreYou()
    {
        return this.Ok();
    }
}
