using Microsoft.Owin;
using System.Threading.Tasks;


namespace OWIN_IISHost
{
    internal class Handlers
    {
        public static Task handler1(IOwinContext context)
        {
            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync("I'm different handler hosted in IIS");
        }
    }
}