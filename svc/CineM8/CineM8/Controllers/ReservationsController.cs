using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CineM8.DAL;
using CineM8.Models;
using System.Diagnostics;

namespace CineM8.Controllers
{
    public class ReservationsController : Controller
    {
        
        DBConnect dBConnect = new DBConnect();
        ReservationDAL reservationDAL;

        // GET: reservations/show/userId
        public ActionResult Show(string userId)
        {
            Debug.WriteLine(userId);
            dBConnect.OpenConnection();
            reservationDAL = new ReservationDAL();
            List<ReservationWithDetails> reservations = new List<ReservationWithDetails>();
            reservations = reservationDAL.GetAllReservationsForUser(Convert.ToInt32(userId));
            dBConnect.CloseConnection();

            return View("~/Views/Reservations/Index.cshtml", reservations);
        }
    }
}