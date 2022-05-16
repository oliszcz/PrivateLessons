using Microsoft.AspNetCore.Mvc;
using PrivateLessons.Infrastructure.Commands.Interfaces;
using PrivateLessons.Infrastructure.Commands.Users;
using PrivateLessons.Infrastructure.DTO;
using PrivateLessons.Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrivateLessons.Api.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<UserDto> Get(string email)
            => await _userService.GetUserAsync(email);

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAll()
            => await _userService.GetAllUsers();

        [HttpPost]
        public async Task Post([FromBody]CreateUser command)
        {
            await _commandDispatcher.DispatchAsync(command);
        }
    }
}
