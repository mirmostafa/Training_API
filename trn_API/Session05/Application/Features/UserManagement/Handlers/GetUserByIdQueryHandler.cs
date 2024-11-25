using MediatR;

using Session05.Application.Features.UserManagement.Queries;

namespace Session05.Application.Features.UserManagement.Handlers;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new UserDto()
        {
            Email = "mirmostafa@hotmail.com",
            Id = 2L,
            Name = "Mohammad Mirmostafa"
        });
    }
}
