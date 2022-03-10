using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeagueOfLegends.Models;

namespace LeagueOfLegends.Controllers
{
    public class ChampionsController : Controller
    {
        LeagueOfLegendsEntities db = new LeagueOfLegendsEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ChampionsList()
        {
            return PartialView(db.Champions.ToList());
        }
    }
}