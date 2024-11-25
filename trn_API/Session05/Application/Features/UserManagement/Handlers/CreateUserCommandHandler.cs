using MediatR;

using Session05.Application.Commands;

namespace Session05.Application.Features.UserManagement.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
{
    public Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(10L);
    }
}
