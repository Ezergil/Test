using System.Web.Mvc;

namespace TestProject.Web.Controllers
{
    public sealed class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
