using PrivateLessons.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLessons.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetUserAsync(Guid id);            //metoda zwracająca użytkownika na podstawie id
        Task<User> GetUserAsync(string email);       //metoda zwracająca użytkownika na podstawie emaila
        Task<IEnumerable<User>> GetAllUsersAsync();  //metoda zwracająca wszystkich użytkowników
        Task AddUserAsync(User user);               //metoda dodająca użytkownika do bazy danych
        Task RemoveUserAsync(Guid id);              //metoda usuwająca użytkownika z bazy danych
        Task UpdateUserAsync(User user);            //metoda aktualizująca dane o użytkowniku
    }
}
