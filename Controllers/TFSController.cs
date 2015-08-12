using Microsoft.AspNet.Mvc;

namespace Dev.WebApp.Controllers
{
    [Route("api")]
    public class TFSController : Controller
    {
        [HttpGet, Route("/api/builds")]
        public JsonResult Builds()
        {
            return Json(new object[]
            {
               new { number = 123465432, name = "CI SDK", author = "João da Silva", status = "Failed", date = "a minute ago", duration = 7 },
               new { number = 123465432, name = "CI INSTALLER", author = "João da Silva", status = "Failed", date = "5 minutes ago", duration = 17.3 },
               new { number = 123465432, name = "CI CONTROLS", author = "João da Silva", status = "Partially Succeeded", date = "12/12/2015 18 =30", duration = 22.8 },
               new { number = 123465432, name = "CI DOCS", author = "João da Silva", status = "Succeeded", date = "12/12/2015 19 =36", duration = 2 },
               new { number = 123465432, name = "DEPLOY DOCS", author = "João da Silva", status = "Succeeded", date = "12/12/2015 19 =30", duration = 5 },
               new { number = 123465432, name = "CI CONTROLS", author = "João da Silva", status = "Partially Succeeded", date = "11/12/2015 12 =40", duration = 22.8 },
            });
        }
        
        [HttpGet, Route("/api/pullrequests")]
        public JsonResult PullRequests()
        {
            return Json(new object[]
            {
                new { repo = "components", @from = "js/menu", to = "master", title = "Create menu component" }
            });
        }
    }
}