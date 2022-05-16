using PrivateLessons.Core.Domain;
using PrivateLessons.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private static ISet<Teacher> _teachers = new HashSet<Teacher>();

        public async Task<Teacher> GetTeacherAsync(Guid userId)
            => await Task.FromResult(_teachers.SingleOrDefault(x => x.UserId == userId));

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
            => await Task.FromResult(_teachers);
        
        public async Task AddTeacherAsync(Teacher teacher)
        {
            _teachers.Add(teacher);
            await Task.CompletedTask;
        }
        public async Task RemoveTeacherAsync(Guid userId)
        {
            var teacher = await GetTeacherAsync(userId);
            _teachers.Remove(teacher);
            await Task.CompletedTask;
        }

        public async Task UpdateTeacherAsync(Teacher Teacher)
        {
            await Task.CompletedTask;
        }
    }
}
