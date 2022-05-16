using PrivateLessons.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLessons.Core.Repositories
{
    public interface ITeacherRepository : IRepository
    {
        Task<Teacher> GetTeacherAsync(Guid userId);                     //metoda zwracająca nauczyciela na podstawie id
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();               //metoda zwracająca wszystkich nauczycieli
        Task AddTeacherAsync(Teacher teacher);                          //metoda dodająca nauczyciela do bazy danych
        Task RemoveTeacherAsync(Guid userId);                           //metoda usuwająca nauczyciela z bazy danych
        Task UpdateTeacherAsync(Teacher teacher);                       //metoda aktualizująca dane o nauczycielu
    }
}
