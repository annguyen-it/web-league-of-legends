using System.Linq;
using System.Web.Mvc;
using LeagueOfLegends.Models;

namespace LeagueOfLegends.Controllers
{
    public class ChampionsController : Controller
    {
        readonly LeagueOfLegendsEntities db = new LeagueOfLegendsEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ChampionsList()
        {
            return PartialView(db.Champions.ToList());
        }

        public ViewResult ChampionDetails(string id)
        {
            var xx = db.Champions.Count();
            Champion champion = db.Champions.FirstOrDefault(x => x.id == id);
            if (champion == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(champion);
        }
    }
}