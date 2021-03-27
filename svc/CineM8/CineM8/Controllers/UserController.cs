using CineM8.DAL;
using CineM8.Models;
using LiteDB;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace CineM8.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        static DBConnect dBConnect = new DBConnect();
        static UserDAL userDAL = new UserDAL();

        [HttpGet]
        [Route("getAll")]
        public JsonResult<List<User>> GetAllUsers()
        {
            dBConnect.OpenConnection();
            List<User> users = new List<User>();
            users = userDAL.GetAllUsers();
            dBConnect.CloseConnection();
            return Json<List<User>>(users);

        }

        [HttpGet]
        [Route("get/{userId}")]
        public JsonResult<List<User>> GetUser(int userId)
        {
            List<User> users = new List<User>();
            dBConnect.OpenConnection();
            users = userDAL.readUser(userId);
            dBConnect.CloseConnection();
            return Json<List<User>>(users);
        }

        [HttpGet]
        [Route("find/{email}")]

        public JsonResult<List<User>> FindUser(string email)
        {
            List<User> users = new List<User>();
            dBConnect.OpenConnection();
            users = userDAL.findUser(email);
            dBConnect.CloseConnection();
            return Json<List<User>>(users);
        }


        [HttpPost]
        [Route("create")]
        public JsonResult<string> CreateUser(User user)
        {
            dBConnect.OpenConnection();
            Debug.WriteLine(user.Email);
            Debug.WriteLine(userDAL.isExistingAccount(user.Email));
            if (userDAL.isExistingAccount(user.Email))
                return Json<string>("Failed!");
            userDAL.createUser(user);
            dBConnect.CloseConnection();
            return Json<string>("Succesfully!");
        }

        [HttpDelete]
        [Route("delete/{userId}")]
        public JsonResult<string> DeleteUser(int userId)
        {
            dBConnect.OpenConnection();
            userDAL.deleteUser(userId);
            string message = "User Deleted Succesfully!";
            dBConnect.CloseConnection();
            return Json<string>(message);
        }

        [HttpPost]
        [Route("login")]
        public JsonResult<string> LoginUser(string email, string password)
        {
            string message = "";
            Debug.WriteLine("wkfawfwapfkawpofkwafkwa");
            Debug.WriteLine(email + " " + password);
            dBConnect.OpenConnection();
            if (userDAL.login(email, password) == true)
            {
                message = "Login Succesfully!";
            }
            else
            {
                message = "Login Failed!";
            }

            dBConnect.CloseConnection();
            return Json<string>(message);
        }

        [HttpPut]
        [Route("update")]
        public JsonResult<string> UpdateUser(int userId, User user)
        {
            dBConnect.OpenConnection();
            userDAL.updateUser(userId, user);
            string message = "User Updated Succesfully!";
            dBConnect.CloseConnection();
            return Json<string>(message);
        }

        /* TEST METHOD   
         *    public IEnumerable<string> GetAllUserss()
              {
                  List<User> users = new List<User>();
                  dBConnect.OpenConnection();
                  users = userDAL.GetAllUsers();
                  dBConnect.CloseConnection();
                  List<string> list = new List<string>();
                  foreach (User usr in users)
                  {
                      list.Add(usr.FirstName);
                  }

                  return list;
              }*/
    }
}
