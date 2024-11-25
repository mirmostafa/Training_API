using MediatR;

using Microsoft.AspNetCore.Mvc;

using Session05.Application.Commands;
using Session05.Application.Features.UserManagement.Queries;

namespace Session05.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        var userId = await _mediator.Send(command);
        return Ok(userId);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(long id)
    {
        var query = new GetUserByIdQuery { UserId = id };
        var user = await _mediator.Send(query);
        return Ok(user);
    }
}
