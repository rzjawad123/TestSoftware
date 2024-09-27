using Domains.Abstractions;
using Domains.Entities.User;
using MediatR;

namespace Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                CreatedAt = DateTime.UtcNow,
                Firstname = command.FirstName,
                Lastname = command.LastName,
                Password = command.Password,
                Username = command.UserName,
                Device = command.Device,
                IpAddress = command.IpAddress
            };
            await _repository.AddAsync(user);
        }
    }
}
