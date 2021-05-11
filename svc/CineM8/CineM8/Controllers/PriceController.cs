using CineM8.DAL;
using CineM8.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using System;
namespace CineM8.Controllers
{
    [RoutePrefix("api/price")]
    public class PriceController : ApiController
    {
        static DBConnect dBConnect = new DBConnect();
        PriceDAL priceDAL;
        [HttpGet]
        [Route("GetPrices")]

        public JsonResult<List<Price>> GetAllPrices()
        {
            priceDAL = new PriceDAL();

            List<Price> prices = new List<Price>();
            prices = priceDAL.GetPrices();

            return Json<List<Price>>(prices);
        }
        [HttpPost]
        [Route("PostNewPrice")]
        public JsonResult<string> PostPrice(Price price)
        {
            dBConnect.OpenConnection();
            priceDAL = new PriceDAL();
            priceDAL.CreatePrice(price);
            dBConnect.CloseConnection();

            return Json<string>("New price added");
        }
    }
}
