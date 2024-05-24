using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BEEKP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Remove("Server"); 
            Response.Headers.Remove("X-AspNet-Version"); 
            Response.Headers.Remove("X-AspNetMvc-Version"); 
            Response.Headers.Remove("x-frame-options");
        }
        protected void Application_Start()
        {
            AntiForgeryConfig.SuppressIdentityHeuristicChecks = false;
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

       

       

    }
}
