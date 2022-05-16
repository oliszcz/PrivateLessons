using Microsoft.EntityFrameworkCore;
using PrivateLessons.Core.Domain;
using PrivateLessons.Core.Repositories;
using PrivateLessons.Infrastructure.EF;
using System;
using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.Repositories
{
    public class TeacherSubjectRepositoryDB : ITeacherSubjectRepository
    {
        private readonly PrivateLessonsContext _context;

        public TeacherSubjectRepositoryDB(PrivateLessonsContext context)
        {
            _context = context;
        }

        public async Task<TeacherSubject> GetTeacherSubjectAsync(Guid userId, Guid subjectId)
            => await _context.TeachersSubjects.SingleOrDefaultAsync(x => x.UserId == userId && x.SubjectId == subjectId);

        public async Task AddTeacherSubjectAsync(TeacherSubject teachersSubjects)
        {
            await _context.TeachersSubjects.AddAsync(teachersSubjects);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeachersSubjectsAsync(Guid userId, Guid subjectId)
        {
            var teachersSubjects = await GetTeacherSubjectAsync(userId, subjectId);
            _context.TeachersSubjects.Remove(teachersSubjects);
            await _context.SaveChangesAsync();
        }
    }
}
