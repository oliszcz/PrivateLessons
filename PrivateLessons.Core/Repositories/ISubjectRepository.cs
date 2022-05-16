using PrivateLessons.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLessons.Core.Repositories
{
    public interface ISubjectRepository : IRepository
    {
        Task<Subject> GetSubjectAsync(Guid subjectId);              //metoda zwracająca przedmiot
        Task<Subject> GetSubjectAsync(string name);                 //metoda zwracająca przedmiot
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();           //metoda zwracająca wszystkie przedmioty
        Task AddSubjectAsync(Subject subject);                      //metoda dodająca przedmiot do bazy danych
        Task DeleteSubjectAsync(Guid subjectId);                    //metoda usuwająca przedmiot z bazy danych
    }
}
