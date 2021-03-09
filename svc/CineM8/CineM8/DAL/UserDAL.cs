using CineM8.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CineM8.DAL
{
    public class UserDAL
    {
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM Users;";
            MySqlDataAdapter da = new MySqlDataAdapter(query, DBConnect.conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Users");
            DataTable dt = ds.Tables["Users"];

            foreach (DataRow dr in dt.Rows)
            {
                string firstName = dr["FirstName"].ToString();
                string lastName = dr["LastName"].ToString();
                string email = dr["email"].ToString();
                string password = dr["pass"].ToString();
                string phoneNumber = dr["phoneNumber"].ToString();
                string cardNumber = dr["cardNumber"].ToString();
                bool isAdmin = Convert.ToBoolean(dr["isAdmin"].ToString());
                User user = new User(firstName,lastName,email,password,phoneNumber,cardNumber,isAdmin);

                users.Add(user);
            }

            return users;
        }
    }
}