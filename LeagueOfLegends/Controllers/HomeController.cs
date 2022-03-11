using System.Web.Mvc;

namespace LeagueOfLegends.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult News()
        {
            return PartialView();
        }
    }
}