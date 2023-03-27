using Owin;
using System;
using System.Web.Routing;

namespace OWIN_IISHost
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //RouteTable.Routes.MapOwinPath("/owin");
        }

    }
}