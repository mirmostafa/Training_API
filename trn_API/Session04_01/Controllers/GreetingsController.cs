using Microsoft.AspNetCore.Mvc;

using Session04_01.Application.Interface;

namespace Session04_01.Controllers;

[ApiController]
[Route("[controller]")]
public class GreetingsController : ControllerBase
{
    private readonly IGreetingsSender _greetings;

    public GreetingsController(IGreetingsSender greetings)
    {
        this._greetings = greetings;
    }

    [HttpGet]
    public IActionResult SayHello()
    {
        return Ok(_greetings.SayHello());
    }
}
