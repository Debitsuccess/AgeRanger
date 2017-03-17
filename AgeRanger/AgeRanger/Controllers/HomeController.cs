
using System.Web.Mvc;


namespace AgeRanger.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }

      
    }
}