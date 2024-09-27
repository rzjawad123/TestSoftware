using MediatR;

namespace Application.Users.Query
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public string UserName { get; set; }
    }
}
