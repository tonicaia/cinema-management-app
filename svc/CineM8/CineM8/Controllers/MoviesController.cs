using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;   
using System.Web.Mvc;
using CineM8.DAL;
using CineM8.Models;

namespace CineM8.Controllers
{
    public class MoviesController : Controller
    {
        DBConnect dBConnect = new DBConnect();
        MovieDAL movieDAL;
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        // GET: /movies/show/id
        public ActionResult Show(int id)
        {
        
            dBConnect.OpenConnection();
            movieDAL = new MovieDAL();

            List<Movie> movies = new List<Movie>();
            movies = movieDAL.readMovie(id);

            dBConnect.CloseConnection();


          return View("~/Views/Movie/Movie.cshtml", movies[0]);
        }
    }
}
