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
        public List<Movie> GetAllMovies()
        {
            List<Movie> movieList = new List<Movie>();
            //cerem la db lista de filme
            //simulare
            Movie m1 = new Movie();
            movieList.Add(m1);
            return movieList;
        }
    }
}
