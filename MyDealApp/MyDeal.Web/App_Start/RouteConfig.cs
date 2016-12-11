using System.Web.Mvc;
using System.Web.Routing;

namespace MyDeal.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Default",
               url: "",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "URL",
                url: "{shortURL}",
                defaults: new { controller = "Home", action = "RedirectToLong", shortUrl = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Otherwise",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
