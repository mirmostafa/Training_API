using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Session11.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class SrmControllerBase : ControllerBase
{
}
