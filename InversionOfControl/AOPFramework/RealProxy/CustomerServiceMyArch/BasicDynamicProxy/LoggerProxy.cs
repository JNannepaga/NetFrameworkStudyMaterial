using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace AOPFramework.RealProxy.CustomerServiceMyArch
{
    internal class LoggerProxy<T> : System.Runtime.Remoting.Proxies.RealProxy
    {
        private readonly T _service;
        public LoggerProxy(T service)
            : base(typeof(T))
        {
            _service = service;
        }

        public void Log(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }

        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage methodCall = msg as IMethodCallMessage;
            MethodInfo methodInfo = methodCall.MethodBase as MethodInfo;

            Log("In Dynamic Proxy - Before executing '{0}'", methodCall.MethodName);
            try
            {
                var result = methodInfo.Invoke(_service, methodCall.InArgs);
                Log("In Dynamic Proxy - After executing '{0}' ", methodCall.MethodName);
                return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
            }
            catch (Exception e)
            {
                Log(string.Format($"In Dynamic Proxy- Exception {e} executing '{methodCall.MethodName}'"));
                return new ReturnMessage(e, methodCall);
            }
        }
    }
}
