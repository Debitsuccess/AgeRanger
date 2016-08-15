using Microsoft.AspNetCore.Mvc;

namespace AgeRanger.Controllers
{
    public class ManagementController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
