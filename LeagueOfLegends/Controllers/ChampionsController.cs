using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueOfLegends.Controllers
{
    public class ChampionsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}