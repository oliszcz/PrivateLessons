using PrivateLessons.Infrastructure.Commands.Interfaces;

namespace PrivateLessons.Infrastructure.Commands.Users
{
    public class ChangeUserPassword : ICommand
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
