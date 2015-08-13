using Microsoft.AspNet.Mvc;

namespace TfsPanel.Controllers
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
