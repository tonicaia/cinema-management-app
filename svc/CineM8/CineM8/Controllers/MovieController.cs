using CineM8.DAL;
using CineM8.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace CineM8.Controllers
{
    [RoutePrefix("api/movies")]
    public class MovieController : ApiController
    {
        static DBConnect dBConnect = new DBConnect();
        MovieDAL movieDAL;
        [HttpGet]
        [Route("GetMovie")]

        public JsonResult<List<Movie>> GetAllMovies()
        {
            movieDAL = new MovieDAL();

            List<Movie> movies = new List<Movie>();
            movies = movieDAL.GetAllMovies();

            return Json<List<Movie>>(movies);
        }

        [HttpGet]
        [Route("ReadMovie/{movieId}")]
        public JsonResult<List<Movie>> ReadMovie(int movieId)
        {
            dBConnect.OpenConnection();
            movieDAL = new MovieDAL();

            List<Movie> movies = new List<Movie>();
            movies = movieDAL.readMovie(movieId);

            dBConnect.CloseConnection();
            return Json<List<Movie>>(movies);

        }

        [HttpPost]
        [Route("PostNewMovie")]
        public JsonResult<string> PostMovie(Movie movie)
        {
            dBConnect.OpenConnection();
            movieDAL = new MovieDAL();
            movieDAL.CreateMovie(movie);
            dBConnect.CloseConnection();

            return Json<string>("Movie name: " + movie.Name + " description: " + movie.Description + " length: " + movie.Length);
        }

        [HttpDelete]
        [Route("DeleteMovie/{movieId}")]
        public JsonResult<string> DeleteMovie(int movieId)
        {
            dBConnect.OpenConnection();
            movieDAL = new MovieDAL();
            movieDAL.deleteMovie(movieId);
            string comment = "Movie Deleted Succesfully!";
            dBConnect.CloseConnection();
            return Json<string>(comment); 
        }

        [HttpPut]
        [Route("UpdateMovie/{movieId}")]
        public JsonResult<string> UpdateMovie(int movieId, Movie movie)
        {
            dBConnect.OpenConnection();
            movieDAL = new MovieDAL();
            movieDAL.updateMovie(movieId, movie);
            string message = "Movie Updated Succesfully!";
            dBConnect.CloseConnection();
            return Json<string>(message);
        }

    }
}
