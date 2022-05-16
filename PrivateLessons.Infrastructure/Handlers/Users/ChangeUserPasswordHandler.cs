using PrivateLessons.Infrastructure.Commands.Interfaces;
using PrivateLessons.Infrastructure.Commands.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        public async Task HandleAsync(ChangeUserPassword command)
        {
            Console.WriteLine("here");
            await Task.CompletedTask;
        }
    }
}
