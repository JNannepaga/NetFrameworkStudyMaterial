using Owin;
using Microsoft.Owin;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(OWIN_IISHost.Startup))]
namespace OWIN_IISHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.Use<LoggerMiddleware>("I'm in startUp");
            app.Run(handler);
        }

        private Task handler(IOwinContext context)
        {
            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync("Hello, world I'm hosted in IIS");
        } 
    }
}
