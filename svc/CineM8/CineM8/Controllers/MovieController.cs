using CineM8.DAL;
using CineM8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CineM8.Controllers
{
    public class MovieController : ApiController
    {
        DBConnect dBConnect;
        MovieDAL movieDAL;
        [HttpGet]
        public IEnumerable<string> GetAllUsers()
        {
            List<Movie> movies = new List<Movie>();
            movieDAL = new MovieDAL();
            dBConnect = new DBConnect();
            dBConnect.OpenConnection();
            movies = movieDAL.GetAllMovies();
            dBConnect.CloseConnection();
            return new string[] { movies[0].Name, movies[0].Description };
        }
    }
}
