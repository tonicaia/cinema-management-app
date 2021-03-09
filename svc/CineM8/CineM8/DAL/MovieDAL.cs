using CineM8.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace CineM8.DAL
{
    public class MovieDAL
    {
        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();
            string query = "SELECT * FROM Movies;";
            MySqlDataAdapter da = new MySqlDataAdapter(query, DBConnect.conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Movies");
            DataTable dt = ds.Tables["Movies"];

            foreach (DataRow dr in dt.Rows)
            {
                string movieName = dr["MovieName"].ToString();
                string description = dr["MovieDescription"].ToString();
                float movieLength = float.Parse(dr["MovieLength"].ToString());
                bool isRunning = Convert.ToBoolean(dr["MovieIsRunning"].ToString());
                Movie movie = new Movie(movieName,description,movieLength,isRunning);
                movie.Id = Convert.ToInt32(dr["movieId"]);

                movies.Add(movie);
            }

            return movies;
        }

        public void CreateMovie(Movie movie)
        {
            MySqlCommand comm = DBConnect.conn.CreateCommand();
            comm.CommandText = "INSERT INTO Movies(MovieName, MovieDescription, MovieLength, MovieIsRunning) VALUES(@MovieName, @MovieDescription, @MovieLength, @MovieIsRunning)";
            comm.Parameters.AddWithValue("@MovieName", movie.Name);
            comm.Parameters.AddWithValue("@MovieDescription", movie.Description);
            comm.Parameters.AddWithValue("@MovieLength", movie.Length);
            comm.Parameters.AddWithValue("@MovieIsRunning", movie.IsRunning);
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Create Movie Error!");
                Console.WriteLine("Error: {0}", e.ToString());
            }
        }

        public List<Movie> readMovie(int id)
        {
            List<Movie> movies = new List<Movie>();
            string query = "SELECT * FROM Movies where movieID = " + id;
            MySqlDataAdapter da = new MySqlDataAdapter(query, DBConnect.conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Movies");
            DataTable dt = ds.Tables["Movies"];

            foreach (DataRow dr in dt.Rows)
            {
                string movieName = dr["MovieName"].ToString();
                string description = dr["MovieDescription"].ToString();
                float movieLength = float.Parse(dr["MovieLength"].ToString());
                bool isRunning = Convert.ToBoolean(dr["MovieIsRunning"].ToString());
                Movie movie = new Movie(movieName, description, movieLength, isRunning);
                movie.Id = id;

                movies.Add(movie);
            }
            return movies;
        }

        public void updateMovie(int id, Movie movie)
        {
            MySqlCommand comm = DBConnect.conn.CreateCommand();
            comm.CommandText = "update Movies set MovieName = @MovieName , MovieDescription = @MovieDescription, MovieLength = @MovieLength, MovieIsRunning = @MovieIsRunning where movieID = @id";
            comm.Parameters.AddWithValue("@id", id);
            comm.Parameters.AddWithValue("@MovieName", movie.Name);
            comm.Parameters.AddWithValue("@MovieDescription", movie.Description);
            comm.Parameters.AddWithValue("@MovieLength", movie.Length);
            comm.Parameters.AddWithValue("@MovieIsRunning", movie.IsRunning);
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Create Movie Error!");
                Console.WriteLine("Error: {0}", e.ToString());
            }
        }

        public void deleteMovie(int id)
        {
            MySqlCommand comm = DBConnect.conn.CreateCommand();
            comm.CommandText = "DELETE from Movies where movieID = @id";
            comm.Parameters.AddWithValue("@id", id);

            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Create Movie Error!");
                Console.WriteLine("Error: {0}", e.ToString());
            }
        }
    }
}