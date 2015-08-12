using Microsoft.AspNet.Mvc;

namespace tfspanel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.TemProject = "SDK";
            return View();
        }
    }
}
