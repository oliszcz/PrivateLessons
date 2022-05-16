using PrivateLessons.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.DTO
{
    public class SubjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> SubjectsTeachers { get; set; }
    }
}
