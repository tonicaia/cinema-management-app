using CineM8.DAL;
using CineM8.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using System;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace CineM8.Controllers
{
    [RoutePrefix("api/reservation")]
    public class ReservationController : ApiController
    {
        static DBConnect dBConnect = new DBConnect();
        ReservationDAL reservationDAL = new ReservationDAL();


        [HttpGet]
        [Route("GetReservationForMovie")]
        public JsonResult<List<Reservation>> GetAllReservationsForMovie(int movieId)
        {

            List<Reservation> reservations = new List<Reservation>();
            dBConnect.OpenConnection();
            reservations = reservationDAL.GetAllReservationsForMovie(movieId);
            dBConnect.CloseConnection();
            return Json<List<Reservation>>(reservations);
        }

        [HttpGet]
        [Route("GetReservation")]

        public JsonResult<List<Reservation>> GetAllReservations()
        {

            List<Reservation> reservations = new List<Reservation>();
            dBConnect.OpenConnection();
            reservations = reservationDAL.GetAllReservations();
            dBConnect.CloseConnection();
            return Json<List<Reservation>>(reservations);
        }

        [HttpGet]
        [Route("GetAllReservationForUser/{userId}")]
        public JsonResult<List<Reservation>> GetAllReservationsForUser(int userId)
        {
            dBConnect.OpenConnection();
            List<Reservation> reservations = new List<Reservation>();
            reservations = reservationDAL.GetAllReservationsForUser(userId);
            dBConnect.CloseConnection();
            return Json<List<Reservation>>(reservations);
        }

        [HttpGet]
        [Route("ReadReservation/{reservationId}")]
        public JsonResult<List<Reservation>> ReadReservation(int reservationId)
        {
            dBConnect.OpenConnection();
            List<Reservation> reservations = new List<Reservation>();
            reservations = reservationDAL.readReservation(reservationId);
            dBConnect.CloseConnection();
            return Json<List<Reservation>>(reservations);
        }

        [HttpPost]
        [Route("PostNewReservation")]
        public JsonResult<string> PostReservation(HttpRequestMessage request)
        {
            dBConnect.OpenConnection();

            string json = request.Content.ReadAsStringAsync().Result;

            JObject jObject = JObject.Parse(json);
            int userId = Convert.ToInt32(jObject["userId"]);
            int movieId = Convert.ToInt32(jObject["movieId"]);
            int cinemaHallId = Convert.ToInt32(jObject["cinemaHallId"]);
            int numberOfSeats = Convert.ToInt32(jObject["numberOfSeats"]);
            DateTime startTime = Convert.ToDateTime(jObject["startTime"]);
            DateTime endTime = Convert.ToDateTime(jObject["endTime"]);
            string seatsNumbers = jObject["seatsNumbers"].ToObject<string>();

      Reservation reservation = new Reservation(userId, movieId, cinemaHallId, numberOfSeats, startTime, endTime, seatsNumbers);


      reservationDAL.createReservation(reservation);
      string comment = "Reservation created succesfully!";
            dBConnect.CloseConnection();

            return Json<string>(comment);
        }

        [HttpDelete]
        [Route("DeleteReservation/{reservationId}")]
        public JsonResult<string> DeleteReservation(int reservationId)
        {
            dBConnect.OpenConnection();

            reservationDAL.deleteReservation(reservationId);
            string comment = "Reservation Deleted Succesfully!";
            dBConnect.CloseConnection();
            return Json<string>(comment);
        }

        [HttpPut]
        [Route("UpdateReservation/{reservationId}")]
        public JsonResult<string> UpdateReservation(int reservationId, Reservation reservation)
        {
            dBConnect.OpenConnection();
            reservationDAL.updateReservation(reservationId, reservation);
            string message = "Movie Updated Succesfully!";
            dBConnect.CloseConnection();
            return Json<string>(message);
        }

    }
}
