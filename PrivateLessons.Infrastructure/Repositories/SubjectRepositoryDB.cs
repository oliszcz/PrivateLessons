using Microsoft.EntityFrameworkCore;
using PrivateLessons.Core.Domain;
using PrivateLessons.Core.Repositories;
using PrivateLessons.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.Repositories
{
    public class SubjectRepositoryDB : ISubjectRepository
    {
        private readonly PrivateLessonsContext _context;

        public SubjectRepositoryDB(PrivateLessonsContext context)
        {
            _context = context;
        }

        public async Task<Subject> GetSubjectAsync(Guid subjectId)
        {
            var subject = await _context.Subjects.SingleOrDefaultAsync(x => x.Id == subjectId);
            subject.TeacherSubjects = _context.TeachersSubjects.Where(x => x.SubjectId == subjectId).ToList();
            return subject;
        }

        public async Task<Subject> GetSubjectAsync(string name)
            => await _context.Subjects.SingleOrDefaultAsync(x => x.Name == name);

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            var subjects = await _context.Subjects.ToListAsync();
            foreach (var subject in subjects)
            {
                subject.TeacherSubjects = _context.TeachersSubjects.Where(x => x.SubjectId == subject.Id).ToList();
            }
            return subjects;
        }

        public async Task AddSubjectAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubjectAsync(Guid subjectId)
        {
            var subject = await GetSubjectAsync(subjectId);
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }
    }
}
