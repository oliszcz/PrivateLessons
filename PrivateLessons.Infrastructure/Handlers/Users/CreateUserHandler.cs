using PrivateLessons.Infrastructure.Commands.Interfaces;
using PrivateLessons.Infrastructure.Commands.Users;
using PrivateLessons.Infrastructure.Services.Interfaces;
using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;
        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterUserAsync(command);
        }
    }
}
