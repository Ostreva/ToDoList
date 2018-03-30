using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ToDoList
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //TODO: issue with routing of navigation passing a null for category
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(null,
                "",
                new
                {
                    controller = "TaskManager",
                    action = "List",
                    category = (string)null,
                    page = 1
                });
            routes.MapRoute(
                 null,
                 "Page{page}",
                 new { Controller = "TaskManager", action = "List" , category = (string)null},
                 new {page = @"\d+"}
            );
            routes.MapRoute(null,
                "{category}",
                new { Controller = "TaskManager", action = "List", page = 1 });

            routes.MapRoute(
                 null,
                 "{category}/Page{page}",
                 new { Controller = "TaskManager", action = "List", category = (string)null },
                 new { page = @"\d+" }
            );
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
