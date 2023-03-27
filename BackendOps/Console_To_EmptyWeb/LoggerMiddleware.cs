using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;

namespace Console_To_EmptyWeb
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