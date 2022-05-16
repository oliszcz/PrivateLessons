using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrivateLessons.Core.Domain
{
    public class Teacher
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public double Raiting { get; set; }                           //ocena nauczyciela na portalu
        [Required]
        public DateTime LastRaiting { get; set; }                     //data ostatniej recenzji
        [Required]
        public int NumberOfRaiting { get; set; }                      //liczba ocen
        [Required]
        public List<TeacherSubject> TeacherSubjects { get; set; }
        public User User { get; set; }


        protected Teacher()
        {

        }

        public Teacher(Guid id)
        {
            UserId = id;
            LastRaiting = DateTime.UtcNow;
            Raiting = 0.0;
            NumberOfRaiting = 0;
        }

        public void SetRaiting(double raiting)
        {
            if(raiting < 0.0)
            {
                throw new Exception("Raiting can not be less than 0.");
            }
            if(raiting > 5.0)
            {
                throw new Exception("Raiting can not be higher than 5.");
            }
            if(Raiting == raiting)
            {
                return;
            }
            Raiting = raiting;
            UpdateRaiting();
        }

        public void UpdateRaiting()
        {
            LastRaiting = DateTime.UtcNow;
        }
    }
}
