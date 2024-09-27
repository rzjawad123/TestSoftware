
using Application.Users;
using Application.Users.Commands;
using Application.Users.Query;
using Domains.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        [HttpGet("GetUser")]
        public async Task<ActionResult<UserDto>> GetUser(GetUserQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult> Create(CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
