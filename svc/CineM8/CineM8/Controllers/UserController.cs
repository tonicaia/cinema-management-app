using CineM8.DAL;
using CineM8.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace CineM8.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        DBConnect dBConnect;
        UserDAL userDAL;

        [HttpGet]
        [Route("getUsers")]
        public JsonResult<List<User>> GetAllUsers()
        {
                dBConnect = new DBConnect();
                dBConnect.OpenConnection();
                userDAL = new UserDAL();

                List<User> users = new List<User>();

                users = userDAL.GetAllUsers();

                dBConnect.CloseConnection();
                return Json<List<User>>(users);

        }

        [HttpGet]
        [Route("readUser")]
        public JsonResult<List<User>> ReadUser()
        {
            userDAL = new UserDAL();
            dBConnect = new DBConnect();
            dBConnect.OpenConnection();
            List<User> users = new List<User>();
            users = userDAL.readUser(1);
            dBConnect.CloseConnection();
            return Json<List<User>>(users);
        }


        [HttpPost]
        [Route("PostNewUser")]
        public void PostNewUser()
        {
            userDAL = new UserDAL();
            dBConnect = new DBConnect();
            dBConnect.OpenConnection();
            User user = new User("Filimon", "Bogdan", "filimonbogdan89@gmail.com", "parola", "0751409660", "402", true);
            userDAL.createUser(user);
            dBConnect.CloseConnection();
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public JsonResult<string> DeleteUser()
        {
            userDAL = new UserDAL();
            dBConnect = new DBConnect();
            dBConnect.OpenConnection();
            userDAL.deleteUser(2);
            string message = "User Deleted Succesfully!";
            dBConnect.CloseConnection();
            return Json<string>(message);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public JsonResult<string> UpdateUser()
        {
            userDAL = new UserDAL();
            dBConnect = new DBConnect();
            dBConnect.OpenConnection();
            User user = new User("Filimon", "Bogdanus", "filimonbogdan89@gmail.com", "parola", "0751409660", "402", true);
            userDAL.updateUser(1,user);
            string message = "User Updated Succesfully!";
            dBConnect.CloseConnection();
            return Json<string>(message);
        }

        /* TEST METHOD   
         *    public IEnumerable<string> GetAllUserss()
              {
                  List<User> users = new List<User>();
                  userDAL = new UserDAL();
                  dBConnect = new DBConnect();
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
