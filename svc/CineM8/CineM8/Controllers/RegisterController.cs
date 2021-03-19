using System.Web.Mvc;

namespace CineM8.Controllers
{
    public class RegisterController : Controller
    {
            public ActionResult Index()
            {
                ViewBag.Title = "Register Page";

                return View();
            }
    }
}