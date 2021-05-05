using CineM8.DAL;
using CineM8.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using System;

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
        public JsonResult<string> PostReservation(Reservation reservation)
        {
            dBConnect.OpenConnection();

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