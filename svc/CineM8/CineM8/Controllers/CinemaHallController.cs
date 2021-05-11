using CineM8.DAL;
using CineM8.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using System;

namespace CineM8.Controllers
{
    [RoutePrefix("api/halls")]
    public class CinemaHallController : ApiController
    {
        static DBConnect dBConnect = new DBConnect();
        CinemaHallDAL cinemaHallDAL;
        [HttpGet]
        [Route("GetHall")]

        public JsonResult<List<CinemaHall>> GetAllCinemaHall()
        {
            cinemaHallDAL = new CinemaHallDAL();

            List<CinemaHall> cinemaHalls = new List<CinemaHall>();
            cinemaHalls = cinemaHallDAL.GetAllCinameHalls();

            return Json<List<CinemaHall>>(cinemaHalls);
        }

        [HttpGet]
        [Route("ReadHall/{hallsId}")]
        public JsonResult<List<CinemaHall>> ReadHall(int hallId)
        {
            dBConnect.OpenConnection();
            cinemaHallDAL = new CinemaHallDAL();

            List<CinemaHall> cinemaHalls = new List<CinemaHall>();
            cinemaHalls = cinemaHallDAL.readCinemaHalls(hallId);

            dBConnect.CloseConnection();
            return Json<List<CinemaHall>>(cinemaHalls);

        }

        [HttpPost]
        [Route("PostNewHall")]
        public JsonResult<string> PostCinemaHall(CinemaHall cinemaHall)
        {
            dBConnect.OpenConnection();
            cinemaHallDAL = new CinemaHallDAL();
            cinemaHallDAL.CreateCinemaHalls(cinemaHall);
            dBConnect.CloseConnection();

            return Json<string>("Hall capacity: " + cinemaHall.Capacity);
        }

        [HttpDelete]
        [Route("DeleteHall/{hallId}")]
        public JsonResult<string> DeleteCinemaHall(int hallId)
        {
            dBConnect.OpenConnection();
            cinemaHallDAL = new CinemaHallDAL();
            cinemaHallDAL.deleteCinemaHalls(hallId);
            string comment = "Hall Deleted Succesfully!";
            dBConnect.CloseConnection();
            return Json<string>(comment);
        }

        [HttpPut]
        [Route("UpdateHall/{hallId}")]
        public JsonResult<string> UpdateCinemaHall(int hallId, CinemaHall cinemaHall)
        {
            dBConnect.OpenConnection();
            cinemaHallDAL = new CinemaHallDAL();
            cinemaHallDAL.updateCinemaHalls(hallId, cinemaHall);
            string message = "Hall Updated Succesfully!";
            dBConnect.CloseConnection();
            return Json<string>(message);
        }
    }
}
