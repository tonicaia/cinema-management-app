using CineM8.DAL;
using CineM8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;

namespace CineM8.Controllers
{
    public class UserController : ApiController
    {
        DBConnect dBConnect;
        UserDAL userDAL;
        [HttpGet]
        public IEnumerable<string> GetAllUsers()
        {
            List<User> users = new List<User>();
            userDAL = new UserDAL();
            dBConnect = new DBConnect();
            dBConnect.OpenConnection();
            users = userDAL.GetAllUsers();
            dBConnect.CloseConnection();
            return new string[] { users[0].FirstName, users[0].Id.ToString()};
        }
    }
}
