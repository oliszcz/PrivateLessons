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
    public class TeacherRepositoryDB : ITeacherRepository
    {
        private readonly PrivateLessonsContext _context;
        public TeacherRepositoryDB(PrivateLessonsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            var teachers = await _context.Teachers.ToListAsync();
            foreach(var teacher in teachers)
            {
                teacher.TeacherSubjects = _context.TeachersSubjects.Where(x => x.UserId == teacher.UserId).ToList();
            }
            return teachers;
        }

        public async Task<Teacher> GetTeacherAsync(Guid userId)
        {
            var teacher = await _context.Teachers.SingleOrDefaultAsync(x => x.UserId == userId);

            if (teacher != null)
            {
                teacher.TeacherSubjects = _context.TeachersSubjects.Where(x => x.UserId == userId).ToList();
            }

            return teacher;
        }


        public async Task AddTeacherAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveTeacherAsync(Guid userId)
        {
            var teacher = await GetTeacherAsync(userId);
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
        }
    }
}
