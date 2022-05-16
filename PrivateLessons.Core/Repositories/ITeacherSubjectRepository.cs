using PrivateLessons.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLessons.Core.Repositories
{
    public interface ITeacherSubjectRepository : IRepository
    {
        Task<TeacherSubject> GetTeacherSubjectAsync(Guid userId, Guid subjectId);
        Task AddTeacherSubjectAsync(TeacherSubject teacherSubject);
        Task DeleteTeachersSubjectsAsync(Guid userId, Guid subjectId);
    }
}
