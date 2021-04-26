using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineM8.Models
{
    public class UserCredentials
    {
        private string email;
        private string password;

        public string Email { get => email; set => email = value; }

        public string Password { get => password; set => password = value; }
    }

}