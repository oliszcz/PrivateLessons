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
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository subjectRepository, ITeacherRepository teacherRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        public async Task<SubjectDto> GetSubjectAsync(string name)
        {
            var subject = await _subjectRepository.GetSubjectAsync(name);

            if(subject == null)
            {
                throw new Exception($"Subject with name: {name} does not exist.");
            }

            return _mapper.Map<Subject, SubjectDto>(subject);
        }

        public async Task<SubjectDto> GetSubjectAsync(Guid id)
        {
            var subject = await _subjectRepository.GetSubjectAsync(id);

            if (subject == null)
            {
                throw new Exception($"Subject with id: {id} does not exist.");
            }

            List<Guid> listOfTeachers = new List<Guid>();

            foreach (var teacherSubject in subject.TeacherSubjects)
            {
                var teacher = await _teacherRepository.GetTeacherAsync(teacherSubject.UserId);
                listOfTeachers.Add(teacher.UserId);
            }

            return new SubjectDto
            {
                Id = subject.Id,
                Name = subject.Name,
                SubjectsTeachers = listOfTeachers
            };
        }

        public async Task<Subject> GetFullSubjectAsync(string name)
        {
            var subject = await _subjectRepository.GetSubjectAsync(name);

            if (subject == null)
            {
                throw new Exception($"Subject with name: {name} does not exist.");
            }

            return subject;
        }

        public async Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync()
        {
            var subjects = await _subjectRepository.GetAllSubjectsAsync();

            if(subjects == null)
            {
                throw new Exception("Currently there are no subjects in database.");
            }

            List<SubjectDto> listOfSubjects = new List<SubjectDto>();
            
            foreach (var subject in subjects)
            {
                List<Guid> listOfTeachers = new List<Guid>();
                
                foreach (var teacherSubject in subject.TeacherSubjects)
                {
                    var teacher = await _teacherRepository.GetTeacherAsync(teacherSubject.UserId);
                    listOfTeachers.Add(teacher.UserId);
                }
                
                var subjectDto = new SubjectDto
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    SubjectsTeachers = listOfTeachers
                };
                listOfSubjects.Add(subjectDto);
            }

            return listOfSubjects;
        }

        public async Task RegisterSubjectAsync(string name)
        {
            var subject = await _subjectRepository.GetSubjectAsync(name);

            if(subject != null)
            {
                return;
            }

            var id = Guid.NewGuid();
            subject = new Subject(id, name);
            await _subjectRepository.AddSubjectAsync(subject);
        }
    }
}
