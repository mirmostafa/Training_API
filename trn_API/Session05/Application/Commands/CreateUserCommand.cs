using MediatR;

namespace Session05.Application.Commands;

public class CreateUserCommand:IRequest<long>
{
    public string Name { get; set; }
    public string Email { get; set; }
}
