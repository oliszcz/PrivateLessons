using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PrivateLessons.Core.Domain
{
    public class User
    {
        private static readonly Regex NameRegex = new Regex(@"^[A-Z][a-z]");
        private static readonly Regex EmailRegex = new Regex(@"^[\w]+([\.][\w]+){0,2}[\@]{1}"
                                                           + @"[\w]+[\.]([a-zA-Z]{2,4})$");
        [Required]
        public Guid Id { get; protected set; }
        [Required]
        public string FirstName { get; protected set; }
        [Required]
        public string LastName { get; protected set; }
        [Required]
        public string Email { get; protected set; }
        [Required]
        public string Password { get; protected set; }
        [Required]
        public string Salt { get; protected set; }
        [Required]
        public string Location { get; protected set; }
        [Required]
        public string Role { get; protected set; }
        [Required]
        public DateTime CreatedAt { get; protected set; }
        [Required]
        public DateTime UpdatedAt { get; protected set; }
        [Required]
        public bool IsTeacher { get; protected set; }       //1 - nauczyciel, 0 - zwykły użytkownik
        public Teacher Teacher { get; protected set; }

        protected User()
        {
                
        }

        public User(Guid id, string firstname, string lastname, string email, 
            string password, string salt, string location, string role, bool isTeacher)
        {
            Id = id;
            SetFirstName(firstname);
            SetLastName(lastname);
            SetEmail(email);
            SetPassword(password);
            Salt = salt;
            Location = location;
            Role = role;
            IsTeacher = isTeacher;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetFirstName(string firstname)
        {
            if(string.IsNullOrWhiteSpace(firstname))
            {
                throw new Exception("The given name is empty or consists of spaces.");
            }
            if(!NameRegex.IsMatch(firstname))
            {
                throw new Exception("Incorrent name.");
            }
            if(firstname.Length < 3 || firstname.Length > 30)
            {
                throw new Exception("Incorrect name length.");
            }
            if(FirstName == firstname)
            {
                return;
            }
            FirstName = firstname;
            Update();
        }

        public void SetLastName(string lastname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new Exception("The given last name is empty or consists of spaces.");
            }
            if (!NameRegex.IsMatch(lastname))
            {
                throw new Exception("Incorrent last name.");
            }
            if(lastname.Length < 3 || lastname.Length > 30)
            {
                throw new Exception("Incorrect last name length.");
            }
            if(LastName == lastname)
            {
                return;
            }
            LastName = lastname;
            Update();
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("The given email is empty or consists of spaces.");
            }
            if (!EmailRegex.IsMatch(email))
            {
                throw new Exception("Incorrent email.");
            }
            if(email.Length < 10 || email.Length > 30)
            {
                throw new Exception("Incorrect email length.");
            }
            if(Email == email)
            {
                return;
            }
            Email = email;
            Update();
        }

        public void SetPassword(string password)
        {
            if(password.Length < 5 || password.Length > 100)
            {
                throw new Exception("Incorrect password length.");
            }
            Password = password;
            Update();
        }

        public void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
