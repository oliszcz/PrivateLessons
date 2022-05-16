using PrivateLessons.Core.Domain;
using PrivateLessons.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.Services.Interfaces
{
    public interface ITeacherService : IService
    {
        Task<TeacherDto> GetTeacherAsync(Guid userId);
        Task<Teacher> GetFullTeacherAsync(Guid userId);
        Task<IEnumerable<TeacherDto>> GetAllTeachersAsync();
        Task RegisterTeacherAsync(Guid userId);
        Task UpdateTeacherAsync(Teacher teacher);
    }
}
