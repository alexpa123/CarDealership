using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarDealershipNew.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default2",
                url: "{controller}/{action}/{vin}",
                defaults: new { controller = "Home", action = "Contact", vin = "" }
            );

            routes.MapRoute(
            name: "Default1",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Sales", action = "Purchase", id = UrlParameter.Optional }
            );

            

            routes.MapRoute(
                name: "Default3",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Edit", id = UrlParameter.Optional }
            );
        }
    }
}
