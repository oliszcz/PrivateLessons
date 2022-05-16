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
    public class TeacherSubjectService : ITeacherSubjectService
    {
        private readonly ITeacherSubjectRepository _teachersServiceRepository;
        private readonly IMapper _mapper;

        public TeacherSubjectService(ITeacherSubjectRepository teachersSubjectsRepository, IMapper mapper)
        {
            _teachersServiceRepository = teachersSubjectsRepository;
            _mapper = mapper;
        }

        public async Task<TeacherSubject> GetFullTeacherSubjectAsync(Guid userId, Guid subjectId)
        {
            var teachersSubject = await _teachersServiceRepository.GetTeacherSubjectAsync(userId, subjectId);
            if(teachersSubject == null)
            {
                throw new Exception($"Teacher with id: {userId} is not assigned to subject with id: {subjectId}.");
            }
            return teachersSubject;
        }

        public async Task RegisterTeacherSubjectAsync(Guid userId, Guid subjectId)
        {
            var teacherSubject = await _teachersServiceRepository.GetTeacherSubjectAsync(userId, subjectId);
            if(teacherSubject != null)
            {
                throw new Exception($"Teacher with id: {userId} is already assigned to subject with id: {subjectId}.");
            }
            teacherSubject = new TeacherSubject(userId, subjectId);
            await _teachersServiceRepository.AddTeacherSubjectAsync(teacherSubject);
        }
    }
}
