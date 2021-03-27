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
                user.Id = Convert.ToInt32(dr["userId"]);

                users.Add(user);
            }

            return users;
        }

        public void createUser(User user)
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
            catch(Exception e)
            {
                Debug.WriteLine("Create User Error!");
                Console.WriteLine("Error: {0}", e.ToString());
            }
        }

        public List<User> readUser(int id)
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM Users where userID = " + id;
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
                User user = new User(firstName, lastName, email, password, phoneNumber, cardNumber, isAdmin);
                user.Id = id;

                users.Add(user);
            }

            return users;
        }

        public void updateUser(int id, User user)
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
        public void deleteUser(int id)
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

        public bool login(string Email, string Pass)
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM Users where email = " + Email;
            MySqlDataAdapter da = new MySqlDataAdapter(query, DBConnect.conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Users");
            DataTable dt = ds.Tables["Users"];

            foreach (DataRow dr in dt.Rows) // itereaza o singura data
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
                Debug.WriteLine(email + " " + Email + " " + password + " " + Pass);
                email ="\"" + email + "\"";
                password = "\"" + password + "\"";
                if (email.Equals(Email.ToString()) && password.Equals(Pass.ToString()))
                {
                    Debug.WriteLine(email);
                    return true;
                }
            }
            return false;
        }

        public bool isExistingAccount(string Email)
        {
            List<User> users = new List<User>();
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

        public List<User> findUser(string Email)
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM Users where email = " + Email;
            MySqlDataAdapter da = new MySqlDataAdapter(query, DBConnect.conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Users");
            DataTable dt = ds.Tables["Users"];

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