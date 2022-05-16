using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PrivateLessons.Core.Domain
{
    public class TeacherSubject
    {
        public Guid UserId { get; set; }
        public Teacher Teacher { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        protected TeacherSubject()
        {

        }

        public TeacherSubject(Guid userId, Guid subjectId)
        {
            UserId = userId;
            SubjectId = subjectId;
        }
    }

}
