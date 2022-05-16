using PrivateLessons.Core.Domain;
using PrivateLessons.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.Services.Interfaces
{
    public interface ITeacherSubjectService : IService
    {
        Task<TeacherSubject> GetFullTeacherSubjectAsync(Guid userId, Guid subjectId);
        Task RegisterTeacherSubjectAsync(Guid userId, Guid subjectId);
    }
}
