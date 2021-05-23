using CineM8.Models;
using MySqlConnector;
using System;
using System.Collections;
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
                    string query = "select * from reservation";
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
                    string seatsNumbers = (string)dr["seatsNumbers"];
                    Reservation reservation = new Reservation(userID, movieID, hallID, numberOfSeats, startTime, endTime, seatsNumbers);

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

        public List<ReservationWithDetails> GetAllReservationsForUser(int userId)
        {
            try
            {
                List<ReservationWithDetails> reservations = new List<ReservationWithDetails>();
                DataSet ds;
                MySqlDataAdapter da;

                using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
                {
                    string query = "select * from reservation r, movies m where r.movieID = m.movieID and r.userID = " + userId;
                    connection.Open();

                    da = new MySqlDataAdapter(query, connection);
                    ds = new DataSet();
                    da.Fill(ds, "Reservation");
                }
                DataTable dt = ds.Tables["Reservation"];

                foreach (DataRow dr in dt.Rows)
                {
                    string movieName = dr["MovieName"].ToString();
                    int hallNumber = Convert.ToInt32(dr["hallID"]);
                    DateTime startTime = Convert.ToDateTime(dr["startTime"]);
                    DateTime endTime = Convert.ToDateTime(dr["endTime"]);
                    int numberOfSeats = Convert.ToInt32(dr["numberOfSeats"]);
                    ReservationWithDetails reservation = new ReservationWithDetails(movieName, hallNumber, startTime, endTime, numberOfSeats);
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
                    string seatsNumbers = (string)dr["seatsNumbers"];
                    Reservation reservation = new Reservation(userID, movieID, hallID, numberOfSeats, startTime, endTime, seatsNumbers);

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
                comm.CommandText = "INSERT INTO reservation(userID, movieID, hallID, numberOfSeats, startTime, endTime, seatsNumbers) " +
                    "VALUES(@userID, @movieID, @hallID, @numberOfSeats, @startTime, @endTime, @seatsNumbers)";
                comm.Parameters.AddWithValue("@userID", reservation.UserId);
                comm.Parameters.AddWithValue("@movieID", reservation.MovieId);
                comm.Parameters.AddWithValue("@hallID", reservation.CinemaHallId);
                comm.Parameters.AddWithValue("@numberOfSeats", reservation.NumberOfSeats);
                comm.Parameters.AddWithValue("@startTime", reservation.StartTime);
                comm.Parameters.AddWithValue("@endTime", reservation.EndTime);
                comm.Parameters.AddWithValue("@seatsNumbers", reservation.SeatsNumbers);
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
                    string seatsNumbers = (string)dr["seatsNumbers"];
                    Reservation reservation = new Reservation(userID, movieID, hallID, numberOfSeats, startTime, endTime, seatsNumbers);

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
                    "movieID = @movieID, hallID = @hallID, numberOfSeats = @numberOfSeats, startTime = @startTime, endTime = @endTime" +
                    "seatsNumbers = @seatsNumbers where reservationID = @id";
                comm.Parameters.AddWithValue("@userID", reservation.UserId);
                comm.Parameters.AddWithValue("@movieID", reservation.MovieId);
                comm.Parameters.AddWithValue("@hallID", reservation.CinemaHallId);
                comm.Parameters.AddWithValue("@numberOfSeats", reservation.NumberOfSeats);
                comm.Parameters.AddWithValue("@startTime", reservation.StartTime);
                comm.Parameters.AddWithValue("@endTime", reservation.EndTime);
                comm.Parameters.AddWithValue("@seatsNumbers", reservation.SeatsNumbers);
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
