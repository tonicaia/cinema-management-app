using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineM8.Models
{
    class User
    {
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private string phoneNb;
        private string cardNb;
        private bool isAdmin;

        public User(string firstName, string lastName, string email, string password, string phoneNb, string cardNb, bool isAdmin)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.phoneNb = phoneNb;
            this.cardNb = cardNb;
            this.isAdmin = isAdmin;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string PhoneNb { get => phoneNb; set => phoneNb = value; }
        public string CardNb { get => cardNb; set => cardNb = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
    }
}