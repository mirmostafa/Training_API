using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Session11.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecuredController: ControllerBase
{
    [Authorize]
    [HttpGet("data")]
    public IActionResult GetData()
    {
        return Ok("این یک داده محافظت‌شده است که فقط کاربران لاگین‌شده می‌توانند ببینند.");
    }
}
