using System.Web.Mvc;

namespace NumberParser.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Home");
        }      
    }
}
