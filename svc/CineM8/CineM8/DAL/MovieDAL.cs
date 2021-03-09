using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CineM8.Models;
using MySqlConnector;

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
                string movieName = dr["name"].ToString();
                string description = dr["description"].ToString();
                float movieLength = float.Parse(dr["length"].ToString());
                bool isRunning = Convert.ToBoolean(dr["isRunning"].ToString());
                Movie movie = new Movie(movieName,description,movieLength,isRunning);
                movies.Add(movie);
            }

            return movies;
        }
    }
}