using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace AOPFramework.RealProxy.CustomerServiceMyArch
{
    class AuthProxy<T> : System.Runtime.Remoting.Proxies.RealProxy
    {
        private readonly T _service;
        public AuthProxy(T service)
            : base(typeof(T))
        {
            _service = service;
        }

        public void SuccessLog(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }

        public void ErrorLog(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }

        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage methodCall = msg as IMethodCallMessage;
            MethodInfo methodInfo = methodCall.MethodBase as MethodInfo;

            if (Thread.CurrentPrincipal.IsInRole("ADMIN"))
            {
                try
                {
                    SuccessLog("You are Authencated");
                    var result = methodInfo.Invoke(_service, methodCall.InArgs);
                    return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
                }
                catch (Exception e)
                {
                    ErrorLog(string.Format($"In Dynamic Proxy- Exception {e} executing '{methodCall.MethodName}'"));
                    return new ReturnMessage(e, methodCall);
                }
            }
            else
            {
                ErrorLog("You are not Authenticated");
                return new ReturnMessage(null,null,0,methodCall.LogicalCallContext, methodCall);
            }
        }
    }
}
