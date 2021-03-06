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
            try
            {
                List<Movie> movies = new List<Movie>();
                DataSet ds;
                MySqlDataAdapter da;

                using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
                {
                    string query = "SELECT * FROM Movies;";
                    connection.Open();

                    da = new MySqlDataAdapter(query, connection);
                    ds = new DataSet();
                    da.Fill(ds, "Movies");
                }
                DataTable dt = ds.Tables["Movies"];

                foreach (DataRow dr in dt.Rows)
                {
                    string movieName = dr["MovieName"].ToString();
                    string description = dr["MovieDescription"].ToString();
                    float movieLength = float.Parse(dr["MovieLength"].ToString());
                    bool isRunning = Convert.ToBoolean(dr["MovieIsRunning"].ToString());
                    string imageURL = dr["ImageURL"].ToString();
                    string videoURL = dr["VideoURL"].ToString();
                    Movie movie = new Movie(movieName, description, movieLength, isRunning, imageURL, videoURL);
                    movie.Id = Convert.ToInt32(dr["movieId"]);

                    movies.Add(movie);
                }

                return movies;

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        public void CreateMovie(Movie movie)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
            {
                MySqlCommand comm = DBConnect.conn.CreateCommand();
                comm.CommandText = "INSERT INTO Movies(MovieName, MovieDescription, MovieLength, MovieIsRunning, ImageURL, VideoURL) VALUES(@MovieName, @MovieDescription, @MovieLength, @MovieIsRunning, @ImageURL, @VideoURL)";
                comm.Parameters.AddWithValue("@MovieName", movie.Name);
                comm.Parameters.AddWithValue("@MovieDescription", movie.Description);
                comm.Parameters.AddWithValue("@MovieLength", movie.Length);
                comm.Parameters.AddWithValue("@MovieIsRunning", movie.IsRunning);
                comm.Parameters.AddWithValue("@ImageURL", movie.ImageURL);
                comm.Parameters.AddWithValue("@VideoURL", movie.VideoURL);
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

        public List<Movie> readMovie(int id)
        {
            List<Movie> movies = new List<Movie>();
            DataSet ds;
            DataTable dt;

            using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
            {
                string query = "SELECT * FROM Movies where movieID = " + id;
                MySqlDataAdapter da = new MySqlDataAdapter(query, DBConnect.conn);
                ds = new DataSet();
                da.Fill(ds, "Movies");
            }
            dt = ds.Tables["Movies"];

            foreach (DataRow dr in dt.Rows)
            {
                string movieName = dr["MovieName"].ToString();
                string description = dr["MovieDescription"].ToString();
                float movieLength = float.Parse(dr["MovieLength"].ToString());
                bool isRunning = Convert.ToBoolean(dr["MovieIsRunning"].ToString());
                string imageURL = dr["ImageURL"].ToString();
                string videoURL = dr["VideoURL"].ToString();
                Movie movie = new Movie(movieName, description, movieLength, isRunning, imageURL, videoURL);
                movie.Id = id;

                movies.Add(movie);
            }
            return movies;
        }

        public void updateMovie(int id, Movie movie)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
            {
                MySqlCommand comm = DBConnect.conn.CreateCommand();
                comm.CommandText = "update Movies set MovieName = @MovieName , MovieDescription = @MovieDescription, MovieLength = @MovieLength, MovieIsRunning = @MovieIsRunning, ImageURL = @ImageURL, VideoURL = @VideoURL where movieID = @id";
                comm.Parameters.AddWithValue("@id", id);
                comm.Parameters.AddWithValue("@MovieName", movie.Name);
                comm.Parameters.AddWithValue("@MovieDescription", movie.Description);
                comm.Parameters.AddWithValue("@MovieLength", movie.Length);
                comm.Parameters.AddWithValue("@MovieIsRunning", movie.IsRunning);
                comm.Parameters.AddWithValue("@ImageURL", movie.ImageURL);
                comm.Parameters.AddWithValue("@VideoURL", movie.VideoURL);
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Update Movie Error!");
                    Console.WriteLine("Error: {0}", e.ToString());
                }
            }
        }

        public void deleteMovie(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
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
                    Debug.WriteLine("Delete Movie Error!");
                    Console.WriteLine("Error: {0}", e.ToString());
                }
            }
        }
    }
}
