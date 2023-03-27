using Owin;
using System.Web.Http;

namespace Console_To_EmptyWeb
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            HttpConfiguration config = new HttpConfiguration();
            
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            builder.Use<LoggerMiddleware>("I'm logged");
        }
    }
}