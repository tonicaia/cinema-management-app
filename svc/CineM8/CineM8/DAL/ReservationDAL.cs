using CineM8.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;


namespace CineM8.DAL
{
    public class ReservationDAL
    {
        public List<Reservation> GetAllReservations()
        {
            try
            {
                List<Reservation> reservations = new List<Reservation>();
                DataSet ds;
                MySqlDataAdapter da;

                using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
                {
                    string query = "SELECT * FROM Reservation;";
                    connection.Open();

                    da = new MySqlDataAdapter(query, connection);
                    ds = new DataSet();
                    da.Fill(ds, "Reservation");
                }
                DataTable dt = ds.Tables["Reservation"];

                foreach (DataRow dr in dt.Rows)
                {
                    int userID = Convert.ToInt32(dr["userID"]);
                    int movieID = Convert.ToInt32(dr["movieID"]);
                    int hallID = Convert.ToInt32(dr["hallID"]);
                    int numberOfSeats = Convert.ToInt32(dr["numberOfSeats"]);
                    DateTime startTime = Convert.ToDateTime(dr["startTime"]);
                    DateTime endTime = Convert.ToDateTime(dr["endTime"]);
                    Reservation reservation = new Reservation(userID, movieID, hallID, numberOfSeats, startTime, endTime);

                    reservations.Add(reservation);
                }

                return reservations;

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        public List<Reservation> GetAllReservationsForUser(int userId)
        {
            try
            {
                List<Reservation> reservations = new List<Reservation>();
                DataSet ds;
                MySqlDataAdapter da;

                using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
                {
                    string query = "SELECT * FROM Reservation where userId = " + userId;
                    connection.Open();

                    da = new MySqlDataAdapter(query, connection);
                    ds = new DataSet();
                    da.Fill(ds, "Reservation");
                }
                DataTable dt = ds.Tables["Reservation"];

                foreach (DataRow dr in dt.Rows)
                {
                    int userID = Convert.ToInt32(dr["userID"]);
                    int movieID = Convert.ToInt32(dr["movieID"]);
                    int hallID = Convert.ToInt32(dr["hallID"]);
                    int numberOfSeats = Convert.ToInt32(dr["numberOfSeats"]);
                    DateTime startTime = Convert.ToDateTime(dr["startTime"]);
                    DateTime endTime = Convert.ToDateTime(dr["endTime"]);
                    Reservation reservation = new Reservation(userID, movieID, hallID, numberOfSeats, startTime, endTime);

                    reservations.Add(reservation);
                }
                return reservations;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        public List<Reservation> GetAllReservationsForMovie(int movieId)
        {
            try
            {
                List<Reservation> reservations = new List<Reservation>();
                DataSet ds;
                MySqlDataAdapter da;

                using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
                {
                    string query = "SELECT * FROM Reservation where movieID = " + movieId;
                    connection.Open();

                    da = new MySqlDataAdapter(query, connection);
                    ds = new DataSet();
                    da.Fill(ds, "Reservation");
                }
                DataTable dt = ds.Tables["Reservation"];

                foreach (DataRow dr in dt.Rows)
                {
                    int userID = Convert.ToInt32(dr["userID"]);
                    int movieID = Convert.ToInt32(dr["movieID"]);
                    int hallID = Convert.ToInt32(dr["hallID"]);
                    int numberOfSeats = Convert.ToInt32(dr["numberOfSeats"]);
                    DateTime startTime = Convert.ToDateTime(dr["startTime"]);
                    DateTime endTime = Convert.ToDateTime(dr["endTime"]);
                    Reservation reservation = new Reservation(userID, movieID, hallID, numberOfSeats, startTime, endTime);

                    reservations.Add(reservation);
                }
                return reservations;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        public void createReservation(Reservation reservation)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
            {
                MySqlCommand comm = DBConnect.conn.CreateCommand();
                comm.CommandText = "INSERT INTO Reservation(userID, movieID, hallID, numberOfSeats, startTime, endTime) " +
                    "VALUES(@userID, @movieID, @hallID, @numberOfSeats, @startTime, @endTime)";
                comm.Parameters.AddWithValue("@userID", reservation.UserId);
                comm.Parameters.AddWithValue("@movieID", reservation.MovieId);
                comm.Parameters.AddWithValue("@hallID", reservation.CinemaHallId);
                comm.Parameters.AddWithValue("@numberOfSeats", reservation.NumberOfSeats);
                comm.Parameters.AddWithValue("@startTime", reservation.StartTime);
                comm.Parameters.AddWithValue("@endTime", reservation.EndTime);
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: {0}", e.ToString());
                }
            }
        }

        public List<Reservation> readReservation(int id)
        {
            try
            {
                List<Reservation> reservations = new List<Reservation>();
                DataSet ds;
                MySqlDataAdapter da;

                using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
                {
                    string query = "SELECT * FROM Reservation where reservationID = " + id;
                    connection.Open();

                    da = new MySqlDataAdapter(query, connection);
                    ds = new DataSet();
                    da.Fill(ds, "Reservation");
                }
                DataTable dt = ds.Tables["Reservation"];

                foreach (DataRow dr in dt.Rows)
                {
                    int userID = Convert.ToInt32(dr["userID"]);
                    int movieID = Convert.ToInt32(dr["movieID"]);
                    int hallID = Convert.ToInt32(dr["hallID"]);
                    int numberOfSeats = Convert.ToInt32(dr["numberOfSeats"]);
                    DateTime startTime = Convert.ToDateTime(dr["startTime"]);
                    DateTime endTime = Convert.ToDateTime(dr["endTime"]);
                    Reservation reservation = new Reservation(userID, movieID, hallID, numberOfSeats, startTime, endTime);

                    reservations.Add(reservation);
                }

                return reservations;

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        public void updateReservation(int id, Reservation reservation)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
            {
                MySqlCommand comm = DBConnect.conn.CreateCommand();
                comm.CommandText = "update Reservation set userID = @userID , " +
                    "movieID = @movieID, hallID = @hallID, numberOfSeats = @numberOfSeats, startTime = @startTime, " +
                    "endTime = @endTime where reservationID = @id";
                comm.Parameters.AddWithValue("@userID", reservation.UserId);
                comm.Parameters.AddWithValue("@movieID", reservation.MovieId);
                comm.Parameters.AddWithValue("@hallID", reservation.CinemaHallId);
                comm.Parameters.AddWithValue("@numberOfSeats", reservation.NumberOfSeats);
                comm.Parameters.AddWithValue("@startTime", reservation.StartTime);
                comm.Parameters.AddWithValue("@endTime", reservation.EndTime);
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: {0}", e.ToString());
                }
            }
        }
        public void deleteReservation(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
            {
                MySqlCommand comm = DBConnect.conn.CreateCommand();
                comm.CommandText = "DELETE from Reservation where reservationID = @id";
                comm.Parameters.AddWithValue("@id", id);

                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: {0}", e.ToString());
                }
            }

        }
    }
}