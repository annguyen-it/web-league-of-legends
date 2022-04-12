using LeagueOfLegends.Models.Components;
using System.Web.Mvc;

namespace LeagueOfLegends.Controllers
{
    public class CanvasRectController : Controller
    {
        // GET: CanvasRect
        public PartialViewResult CanvasRect(CanvasRect canvasRect)
        {
            return PartialView(canvasRect);
        }
    }
}