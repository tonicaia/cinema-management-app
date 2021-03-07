using CineM8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace CineM8.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> GetAllUsers()
        {
            return new string[] { "toni", "caia","exemplu" };
        }
    }
}
