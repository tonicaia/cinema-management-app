using CineM8.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;


namespace CineM8.DAL
{
    public class UserDAL
    {
        public List<User> GetAllUsers()
        {
            try
            {
                List<User> users = new List<User>();
                DataSet ds;
                MySqlDataAdapter da;

                using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
                {
                    string query = "SELECT * FROM Users;";
                    connection.Open();

                    da = new MySqlDataAdapter(query, connection);
                    ds = new DataSet();
                    da.Fill(ds, "Users");
                }
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
                        User user = new User(firstName, lastName, email, password, phoneNumber, cardNumber, isAdmin);
                        user.Id = Convert.ToInt32(dr["userId"]);

                        users.Add(user);
                    }

                    return users;
               
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        public void createUser(User user)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
            {
                MySqlCommand comm = DBConnect.conn.CreateCommand();
                comm.CommandText = "INSERT INTO Users(FirstName, LastName, email, pass, phoneNumber, cardNumber, isAdmin) VALUES(@FirstName, @LastName, @email, @pass, @phoneNumber, @cardNumber, @isAdmin)";
                comm.Parameters.AddWithValue("@FirstName", user.FirstName);
                comm.Parameters.AddWithValue("@LastName", user.LastName);
                comm.Parameters.AddWithValue("@email", user.Email);
                comm.Parameters.AddWithValue("@pass", user.Password);
                comm.Parameters.AddWithValue("@phoneNumber", user.PhoneNb);
                comm.Parameters.AddWithValue("@cardNumber", user.CardNb);
                comm.Parameters.AddWithValue("@isAdmin", user.IsAdmin);
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Create User Error!");
                    Console.WriteLine("Error: {0}", e.ToString());
                }
            }
        }

        public List<User> readUser(int id)
        {
            List<User> users = new List<User>();
            DataSet ds;
            DataTable dt;

            using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
            {
                users = new List<User>();
                string query = "SELECT * FROM Users where userID = " + id;
                MySqlDataAdapter da = new MySqlDataAdapter(query, DBConnect.conn);
                ds = new DataSet();
                da.Fill(ds, "Users");
            }
            dt = ds.Tables["Users"];

            foreach (DataRow dr in dt.Rows)
            {
                string firstName = dr["FirstName"].ToString();
                string lastName = dr["LastName"].ToString();
                string email = dr["email"].ToString();
                string password = dr["pass"].ToString();
                string phoneNumber = dr["phoneNumber"].ToString();
                string cardNumber = dr["cardNumber"].ToString();
                bool isAdmin = Convert.ToBoolean(dr["isAdmin"].ToString());
                User user = new User(firstName, lastName, email, password, phoneNumber, cardNumber, isAdmin);
                user.Id = id;

                users.Add(user);
            }

            return users;
        }

        public void updateUser(int id, User user)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
            {
                MySqlCommand comm = DBConnect.conn.CreateCommand();
                comm.CommandText = "update Users set FirstName = @firstname , LastName = @lastname, email = @email, pass = @pass, phoneNumber = @phoneNumber, cardNumber = @cardNumber, isAdmin = @isAdmin where userID = @id";
                comm.Parameters.AddWithValue("@id", id);
                comm.Parameters.AddWithValue("@FirstName", user.FirstName);
                comm.Parameters.AddWithValue("@LastName", user.LastName);
                comm.Parameters.AddWithValue("@email", user.Email);
                comm.Parameters.AddWithValue("@pass", user.Password);
                comm.Parameters.AddWithValue("@phoneNumber", user.PhoneNb);
                comm.Parameters.AddWithValue("@cardNumber", user.CardNb);
                comm.Parameters.AddWithValue("@isAdmin", user.IsAdmin);
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Create User Error!");
                    Console.WriteLine("Error: {0}", e.ToString());
                }
            }
        }
        public void deleteUser(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
            {
                MySqlCommand comm = DBConnect.conn.CreateCommand();
                comm.CommandText = "DELETE from Users where userID = @id";
                comm.Parameters.AddWithValue("@id", id);

                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Create User Error!");
                    Console.WriteLine("Error: {0}", e.ToString());
                }
            }

        }

        public bool login(string Email, string Pass)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
            {
                MySqlCommand comm = DBConnect.conn.CreateCommand();
                comm.CommandText = "select count(*) from users where email = @email AND pass = @pass";
                comm.Parameters.AddWithValue("@email", Email);
                comm.Parameters.AddWithValue("@pass", Pass);
                int result = 0;
                try
                {
                    Debug.WriteLine(Email);
                    Debug.WriteLine(Pass);
                    result = Convert.ToInt32(comm.ExecuteScalar());
                    Debug.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Debug.WriteLine("Execute Scalar error");
                }
                if (result != 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool isExistingAccount(string Email)
        {
            List<User> users = new List<User>();
            using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
            {
                MySqlCommand comm = DBConnect.conn.CreateCommand();
                comm.CommandText = "Select * from Users where email = @Email";
                comm.Parameters.AddWithValue("@Email", Email);
                Debug.WriteLine(Email);
                Debug.WriteLine(comm.ExecuteNonQuery());

                try
                {
                    if (comm.ExecuteNonQuery() > 0)
                        return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Verify User Error!");
                    Console.WriteLine("Error: {0}", e.ToString());
                }
                return false;
            }
        }

        public List<User> findUser(string Email)
        {
            List<User> users = new List<User>();
            DataSet ds;
            DataTable dt;

            using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
            {
                string query = "SELECT * FROM Users where email = " + Email;
                MySqlDataAdapter da = new MySqlDataAdapter(query, DBConnect.conn);
                ds = new DataSet();
                da.Fill(ds, "Users");
                dt = ds.Tables["Users"];

                foreach (DataRow dr in dt.Rows)
                {
                    int id = Convert.ToInt32(dr["userId"]);
                    string firstName = dr["FirstName"].ToString();
                    string lastName = dr["LastName"].ToString();
                    string email = dr["email"].ToString();
                    string password = dr["pass"].ToString();
                    string phoneNumber = dr["phoneNumber"].ToString();
                    string cardNumber = dr["cardNumber"].ToString();
                    bool isAdmin = Convert.ToBoolean(dr["isAdmin"].ToString());
                    User user = new User(firstName, lastName, email, password, phoneNumber, cardNumber, isAdmin);
                    user.Id = id;

                    users.Add(user);
                }

                return users;
            }
        }
    }
}