using Microsoft.AspNetCore.Mvc;

using Session05.Application.Interfaces;

namespace Session05.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _emailService;

    // Using in a Controller
    public NotificationController(INotificationService emailService)
    {
        this._emailService = emailService;
    }

    [HttpPost]
    public void Post(string to)
    {
        this._emailService.Notify(to, "Hello", "Welcome!");
    }
}