using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BigLinguaProject.UI {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "General",
                url: "{controller}/{action}",
                defaults: new { controller = "Auth", action = "Index" }
            );
            routes.MapRoute(
                name: "forAuthorizedUsers",
                url: "{username}/notebook/index",
                defaults: new { controller = "notebook", action = "index" }
            );
        }
    }
}