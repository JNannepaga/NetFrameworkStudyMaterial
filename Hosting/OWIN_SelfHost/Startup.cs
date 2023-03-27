using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OWIN_SelfHost.Startup))]

namespace OWIN_SelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseErrorPage();
            app.Run(handler);
        }

        private Task handler(IOwinContext context)
        {
            context.Response.ContentType = "text/plain";
            //throw new Exception("Random Exception");
            return context.Response.WriteAsync("Hello, world.");
        }
    }
}
