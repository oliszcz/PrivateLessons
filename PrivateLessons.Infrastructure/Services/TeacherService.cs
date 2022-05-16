using AutoMapper;
using PrivateLessons.Core.Domain;
using PrivateLessons.Core.Repositories;
using PrivateLessons.Infrastructure.DTO;
using PrivateLessons.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, ISubjectRepository subjectRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }
        public async Task<TeacherDto> GetTeacherAsync(Guid userId)
        {
            var teacher = await _teacherRepository.GetTeacherAsync(userId);

            if (teacher == null)
            {
                throw new Exception($"Teacher with id: {userId} does not exist.");
            }

            List<ListOfSubjectsDto> listOfSubjects = new List<ListOfSubjectsDto>();

            foreach (var teacherSubject in teacher.TeacherSubjects)
            {
                var subject = await _subjectRepository.GetSubjectAsync(teacherSubject.SubjectId);
                var elementDto = new ListOfSubjectsDto
                {
                    Id = subject.Id,
                    Name = subject.Name
                };
                listOfSubjects.Add(elementDto);
            }

            return new TeacherDto
            {
                UserId = teacher.UserId,
                Raiting = teacher.Raiting,
                NumberOfRaiting = teacher.NumberOfRaiting,
                TeachersSubjects = listOfSubjects
            };
        }

        public async Task<Teacher> GetFullTeacherAsync(Guid userId)
        {
            var teacher = await _teacherRepository.GetTeacherAsync(userId);

            if (teacher == null)
            {
                throw new Exception($"Teacher with id: {userId} does not exist.");
            }

            return teacher;
        }

        public async Task<IEnumerable<TeacherDto>> GetAllTeachersAsync()
        {
            var teachers = await _teacherRepository.GetAllTeachersAsync();

            if(teachers == null)
            {
                throw new Exception("Currently there are no teachers in database.");
            }

            var listOfTeachers = new List<TeacherDto>();

            foreach (var teacher in teachers)
            {
                var listOfSubjects = new List<ListOfSubjectsDto>();

                foreach (var teacherSubject in teacher.TeacherSubjects)
                {
                    var subject = await _subjectRepository.GetSubjectAsync(teacherSubject.SubjectId);
                    var elementDto = new ListOfSubjectsDto 
                    { 
                        Id = subject.Id, 
                        Name = subject.Name 
                    };
                    listOfSubjects.Add(elementDto);
                }

                var teacherDto = new TeacherDto
                {
                    UserId = teacher.UserId,
                    Raiting = teacher.Raiting,
                    NumberOfRaiting = teacher.NumberOfRaiting,
                    TeachersSubjects = listOfSubjects
                };

                listOfTeachers.Add(teacherDto);
            }
            return listOfTeachers;
        }

        public async Task RegisterTeacherAsync(Guid userId)
        {
            var teacher = await _teacherRepository.GetTeacherAsync(userId);

            if(teacher != null)
            {
                throw new Exception($"Teacher with id: {userId} already exists.");
            }

            teacher = new Teacher(userId);
            await _teacherRepository.AddTeacherAsync(teacher);
        }

        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            await _teacherRepository.UpdateTeacherAsync(teacher);
        }
    }
}
