using Microsoft.AspNetCore.Mvc;

namespace Session02.Controllers;

[ApiController]
[Route("Bye")]
//[Route("[controller]")]
public class SalamController : ControllerBase
{
    [HttpGet]
    public IActionResult HowAreYou()
    {
        return this.Ok();
    }
}
