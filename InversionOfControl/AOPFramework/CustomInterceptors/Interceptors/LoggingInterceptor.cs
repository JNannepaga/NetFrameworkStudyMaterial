using System;
using System.Reflection;

namespace AOPFramework.CustomInterceptors
{
    public class LoggingInterceptor : InterceptingHandler
    {
        public override object Execute<T, TResult>(Func<T, TResult> request, T reqParams)
        {
            Console.WriteLine($"{DateTime.Now} :: {request.GetMethodInfo().Name}");
            return base.Execute<T, TResult>(request, reqParams);
        }
    }
}
