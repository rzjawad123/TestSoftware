using Application.Users.Query;
using Domains.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery,UserDto>
    {
        private readonly IUserRepository _userRepository;
        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(query.UserName);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            // return _mapper.Map<UserDto>(user)
            var dto = new UserDto
            {
                Username = user.Username,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Password = HashPassword(user.Password),
                CreatedAt = DateTime.Now
            };
            return dto;
        }
    }
}
