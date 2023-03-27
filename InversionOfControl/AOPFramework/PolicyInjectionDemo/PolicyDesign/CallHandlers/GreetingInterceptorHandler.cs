using System;
using Unity.Interception.PolicyInjection.Pipeline;

namespace AOPFramework.PolicyInjectionDemo
{
    public class GreetingInterceptorHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Console.WriteLine("Hello Service");
            IMethodReturn result = getNext().Invoke(input, getNext);
            return result;
        }
    }
}
