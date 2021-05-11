using CineM8.DAL;
using CineM8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CineM8.Controllers
{
    public class PricesController : Controller
    {
        DBConnect dBConnect = new DBConnect();
        PriceDAL priceDAL;
        // GET: Prices
        public ActionResult Index()
        {
            dBConnect.OpenConnection();
            priceDAL = new PriceDAL();

            List<Price> prices = new List<Price>();
            prices = priceDAL.GetPrices();

            dBConnect.CloseConnection();


            return View("~/Views/Price/Index.cshtml", prices);
        }
    }
}