using System.Web.Mvc;
using System.Web.Routing;

namespace LeagueOfLegends
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ChampionsList",
                url: "Champions",
                defaults: new { action = "Index", controller = "Champions" }
            );

            routes.MapRoute(
                name: "ChampionsDetails",
                url: "Champions/{id}",
                defaults: new { action = "ChampionDetails", controller = "Champions", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
