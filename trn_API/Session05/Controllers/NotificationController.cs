using Microsoft.AspNetCore.Mvc;

using Session05.Application.Interfaces;
using Session05.Application.Services;

namespace Session05.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    // Using in a Controller
    public NotificationController(INotificationService notificationService)
    {
        this._notificationService = notificationService;
    }

    [HttpPost("{to}")]
    public void Post(string to)
    {
        this._notificationService.Notify(to, "Hello", "Welcome!");
    }
}