using PrivateLessons.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.DTO
{
    public class TeacherDto
    {
        public Guid UserId { get; set; }
        public double Raiting { get; set; }
        public int NumberOfRaiting { get; set; }
        public List<ListOfSubjectsDto> TeachersSubjects { get; set; }
    }
}
