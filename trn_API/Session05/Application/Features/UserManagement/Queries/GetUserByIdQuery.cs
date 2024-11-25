using MediatR;

namespace Session05.Application.Features.UserManagement.Queries;

public class GetUserByIdQuery:IRequest<UserDto>
{
    public long UserId { get; set; }
}
