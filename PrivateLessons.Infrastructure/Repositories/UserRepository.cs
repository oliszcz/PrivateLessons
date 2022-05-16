using PrivateLessons.Core.Domain;
using PrivateLessons.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        //private static ISet<User> _users = new HashSet<User>();
        private static ISet<User> _users = new HashSet<User>
        {
            new User(Guid.NewGuid(),"First", "User", "user1@email.com", "Secret", "salt", "somewhere", "user", false),
            new User(Guid.NewGuid(),"Second", "User", "user2@email.com", "Secret", "salt", "somewhere", "user", true),
            new User(Guid.NewGuid(),"Third", "User", "user3@email.com", "Secret", "salt", "somewhere", "user", false)
        };

        public async Task<User> GetUserAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetUserAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Email == email.ToLowerInvariant()));

        public async Task<IEnumerable<User>> GetAllUsersAsync()
            => await Task.FromResult(_users);

        public async Task AddUserAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task RemoveUserAsync(Guid id)
        {
            var user = await GetUserAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateUserAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}
