using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrivateLessons.Core.Domain
{
    public class Subject
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<TeacherSubject> TeacherSubjects { get; set; }

        protected Subject()
        {

        }

        public Subject(Guid id, string name)
        {
            Id = id;
            SetName(name);
        }

        public void SetName(string name)
        {
            if(String.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Invalid subject name.");
            }
            Name = name;
        }
    }
}
