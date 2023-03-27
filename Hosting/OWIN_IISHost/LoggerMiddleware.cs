using Microsoft.Owin;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OWIN_IISHost
{
    public class LoggerMiddleware : OwinMiddleware
    {
        private readonly string _logmsg;

        public LoggerMiddleware(OwinMiddleware nextMiddleware, string logmsg)
            : base(nextMiddleware)
        {
            _logmsg = logmsg;
        }

        public override Task Invoke(IOwinContext context)
        {
             
            Debug.WriteLine("==========Logging Initiated==========");
            return Next.Invoke(context);
        }
    }
}