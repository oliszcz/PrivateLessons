using PrivateLessons.Infrastructure.Commands.Interfaces;
using System.Collections.Generic;

namespace PrivateLessons.Infrastructure.Commands.Users
{
    public class CreateUser : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }
        public bool IsTeacher { get; set; }
        public ISet<string> Subjects { get; set; }
    }
}
