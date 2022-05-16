using PrivateLessons.Core.Domain;
using PrivateLessons.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.Services.Interfaces
{
    public interface ISubjectService : IService
    {
        Task<SubjectDto> GetSubjectAsync(Guid id);
        Task<SubjectDto> GetSubjectAsync(string name);
        Task<Subject> GetFullSubjectAsync(string name);
        Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync();
        Task RegisterSubjectAsync(string name);
    }
}
