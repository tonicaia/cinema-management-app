using CineM8.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace CineM8.DAL
{
    public class CinemaHallDAL
    {
        public List<CinemaHall> GetAllCinameHalls()
        {
            try
            {
                List<CinemaHall> cinemaHalls = new List<CinemaHall>();
                DataSet ds;
                MySqlDataAdapter da;

                using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
                {
                    string query = "SELECT * FROM halls;";
                    connection.Open();

                    da = new MySqlDataAdapter(query, connection);
                    ds = new DataSet();
                    da.Fill(ds, "halls");
                }
                DataTable dt = ds.Tables["halls"];

                foreach (DataRow dr in dt.Rows)
                {
                    int hallCapacity = int.Parse(dr["capacity"].ToString());
                    CinemaHall cinemaHall = new CinemaHall(hallCapacity);
                    cinemaHall.Id = Convert.ToInt32(dr["hallID"]);

                    cinemaHalls.Add(cinemaHall);
                }

                return cinemaHalls;

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;

        }
        public void CreateCinemaHalls(CinemaHall cinemaHall)
        {
            MySqlCommand comm = DBConnect.conn.CreateCommand();
            comm.CommandText = "INSERT INTO halls(capacity) VALUES(@hallCapacity)";
            comm.Parameters.AddWithValue("@hallCapacity", cinemaHall.Capacity);
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Create Hall Error!");
                Console.WriteLine("Error: {0}", e.ToString());
            }
        }

        public List<CinemaHall> readCinemaHalls(int id)
        {
            List<CinemaHall> cinemaHalls = new List<CinemaHall>();
            string query = "SELECT * FROM halls where hallID = " + id;
            MySqlDataAdapter da = new MySqlDataAdapter(query, DBConnect.conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "halls");
            DataTable dt = ds.Tables["halls"];

            foreach (DataRow dr in dt.Rows)
            {
                int hallCapacity = int.Parse(dr["capacity"].ToString());
                CinemaHall cinemaHall = new CinemaHall(hallCapacity);
                cinemaHall.Id = id;

                cinemaHalls.Add(cinemaHall);
            }
            return cinemaHalls;
        }

        public void updateCinemaHalls(int id, CinemaHall cinemaHall)
        {
            MySqlCommand comm = DBConnect.conn.CreateCommand();
            comm.CommandText = "update halls set capacity = @hallCapacity where hallID = @id";
            comm.Parameters.AddWithValue("@id", id);
            comm.Parameters.AddWithValue("@hallCapacity", cinemaHall.Capacity);
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Update Hall Error!");
                Console.WriteLine("Error: {0}", e.ToString());
            }
        }

        public void deleteCinemaHalls(int id)
        {
            MySqlCommand comm = DBConnect.conn.CreateCommand();
            comm.CommandText = "DELETE from halls where hallID = @id";
            comm.Parameters.AddWithValue("@id", id);

            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Delete Hall Error!");
                Console.WriteLine("Error: {0}", e.ToString());
            }
        }
    }

}
