using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using MySqlConnector;

namespace CineM8.DAL
{
    public class DBConnect
    {
        public static MySqlConnection conn = null;
        public void OpenConnection()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "Server=localhost;Database=cinemadb;Uid=root;Pwd=root;Allow User Variables=True"; // alow user variables  https://stackoverflow.com/questions/22597617/parameter-myleft-must-be-defined
            try
            {
                conn.Open();
                Debug.WriteLine("Connection Succesfuly!");
            }
            catch (Exception e)
            {
                Console.WriteLine("DB connect error!");
                Console.WriteLine("Error: {0}", e.ToString());
            }
        }

        public void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}