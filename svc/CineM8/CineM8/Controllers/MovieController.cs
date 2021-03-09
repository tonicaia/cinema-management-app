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
        DBConnect dBConnect;
        MovieDAL movieDAL;
        [HttpGet]
        [Route("GetMovie")]

        public JsonResult<List<Movie>> GetAllMovies()
        {
            dBConnect = new DBConnect();
            dBConnect.OpenConnection();
            movieDAL = new MovieDAL();

            List<Movie> movies = new List<Movie>();
            movies = movieDAL.GetAllMovies();

            dBConnect.CloseConnection();
            return Json<List<Movie>>(movies);
        }

        [HttpGet]
        [Route("ReadMovie")]
        public JsonResult<List<Movie>> ReadMovie()
        {
            dBConnect = new DBConnect();
            dBConnect.OpenConnection();
            movieDAL = new MovieDAL();

            List<Movie> movies = new List<Movie>();
            movies = movieDAL.readMovie(1);

            dBConnect.CloseConnection();
            return Json<List<Movie>>(movies);

        }

        [HttpPost]
        [Route("PostNewMovie")]
        public void PostMovie()
        {
            dBConnect = new DBConnect();
            dBConnect.OpenConnection();
            movieDAL = new MovieDAL();

            Movie movie = new Movie("Scary movie", "it's a scary movie", 89, false);
            movieDAL.CreateMovie(movie);
            dBConnect.CloseConnection();
        }

        [HttpDelete]
        [Route("DeleteMovie")]
        public JsonResult<string> DeleteMovie()
        {
            dBConnect = new DBConnect();
            dBConnect.OpenConnection();
            movieDAL = new MovieDAL();
            movieDAL.deleteMovie(2);
            string comment = "Movie Deleted Succesfully!";
            dBConnect.CloseConnection();
            return Json<string>(comment); 
        }

        [HttpPut]
        [Route("UpdateMovie")]
        public JsonResult<string> UpdateMovie()
        {
            dBConnect = new DBConnect();
            dBConnect.OpenConnection();
            movieDAL = new MovieDAL();
            Movie movie = new Movie("Scary Movie 5", "it's a scary movie but also funny", 91, false); ;
            movieDAL.updateMovie(1, movie);
            string message = "Movie Updated Succesfully!";
            dBConnect.CloseConnection();
            return Json<string>(message);
        }

        /*
        public IEnumerable<string> GetAllUsers()
        {
            List<Movie> movies = new List<Movie>();
            movieDAL = new MovieDAL();
            dBConnect = new DBConnect();
            dBConnect.OpenConnection();
            movies = movieDAL.GetAllMovies();
            dBConnect.CloseConnection();
            return new string[] { movies[0].Name, movies[0].Description };
        } */
    }
}
