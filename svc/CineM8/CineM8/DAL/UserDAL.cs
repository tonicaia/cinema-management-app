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
            string query = "SELECT * FROM Student;";
            MySqlDataAdapter da = new MySqlDataAdapter(query, DBConnect.conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Student");
            DataTable dt = ds.Tables["Student"];

            foreach (DataRow dr in dt.Rows)
            {
                User user = new User();
                user.FirstName = dr["name"].ToString();
                user.Id = Convert.ToInt32(dr["studentID"]);

                users.Add(user);
            }

            return users;
        }
    }
}