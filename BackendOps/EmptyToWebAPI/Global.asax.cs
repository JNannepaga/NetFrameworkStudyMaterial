using System;
using System.Web.Http;

namespace EmptyToWebAPI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(MyWebAPIConfig.Register);
        }

    }
}