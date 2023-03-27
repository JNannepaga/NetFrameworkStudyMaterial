using System;
using System.Reflection;

namespace AOPFramework.CustomInterceptors
{
    public class AuthInterceptor : InterceptingHandler
    {
        public override object Execute<T, TResult>(Func<T, TResult> request, T reqParams)
        {
            Console.WriteLine($"{DateTime.Now} :: You are authorized");
            return base.Execute<T,TResult>(request, reqParams);
        }
    }
}
