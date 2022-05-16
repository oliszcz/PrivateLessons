using PrivateLessons.Infrastructure.Commands.Users;
using PrivateLessons.Infrastructure.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.Services.Interfaces
{
    public interface IUserService : IService
    {
        Task<UserDto> GetUserAsync(string email);
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task RegisterUserAsync(CreateUser command);
    }
}
