using AutoMapper;
using PrivateLessons.Core.Domain;
using PrivateLessons.Core.Repositories;
using PrivateLessons.Infrastructure.Commands.Users;
using PrivateLessons.Infrastructure.DTO;
using PrivateLessons.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeacherService _teacherService;
        private readonly ISubjectService _subjectService;
        private readonly ITeacherSubjectService _teacherSubjectService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, ITeacherService teacherService,
            ISubjectService subjectService, ITeacherSubjectService teacherSubjectService, IMapper mapper)
        {
            _userRepository = userRepository;
            _teacherService = teacherService;
            _subjectService = subjectService;
            _teacherSubjectService = teacherSubjectService;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserAsync(string email)
        {
            var user = await _userRepository.GetUserAsync(email);
            if(user == null)
            {
                throw new Exception($"User with email: {email} does not exist.");
            }
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            if(users == null)
            {
                throw new Exception("Currently there are no users in database.");
            }
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task RegisterUserAsync(CreateUser command)
        {
            var user = await _userRepository.GetUserAsync(command.Email);
            if(user != null)
            {
                throw new Exception($"User with id: {command.Email} already exists.");
            }
            var id = Guid.NewGuid();
            var salt = Guid.NewGuid().ToString();
            user = new User(id, command.FirstName, command.LastName, command.Email, command.Password, salt, command.Location, command.Role, command.IsTeacher);
            await _userRepository.AddUserAsync(user);
            if (command.IsTeacher)
            {
                await _teacherService.RegisterTeacherAsync(id);
                foreach (var subject in command.Subjects)
                {
                    await _subjectService.RegisterSubjectAsync(subject);
                    var registeredSubject = await _subjectService.GetFullSubjectAsync(subject);
                    await _teacherSubjectService.RegisterTeacherSubjectAsync(user.Id, registeredSubject.Id);
                }
            }
        }
    }
}
