using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Session11.Controllers;

public class SecuredController: SrmControllerBase
{
    [HttpGet("data")]
    public IActionResult GetData()
    {
        return Ok("این یک داده محافظت‌شده است که فقط کاربران لاگین‌شده می‌توانند ببینند.");
    }

    [AllowAnonymous]
    [HttpGet("data2")]
    public IActionResult GetData2()
    {
        return Ok("این یک داده محافظت‌ نشده است که همه کاربران می‌توانند ببینند.");
    }


}
