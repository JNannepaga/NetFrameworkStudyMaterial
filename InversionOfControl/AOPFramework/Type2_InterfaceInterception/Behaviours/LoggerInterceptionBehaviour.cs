using System;
using System.Collections.Generic;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace AOPFramework.Type2_InterfaceInterception
{
    public class LoggerInterceptionBehaviour : IInterceptionBehavior
    {
        public bool WillExecute => true;

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            InfoLog(String.Format("Invoking method {0} at {1}", input.MethodBase, DateTime.Now.ToLongTimeString()));
            var result = getNext().Invoke(input, getNext);

            if (result.Exception != null)
            {
                ErrorLog(String.Format("Method {0} threw exception {1}.",
                  input.MethodBase, result.Exception.Message));
            }

            return result;
        }

        public void SuccessLog(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }

        public void InfoLog(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }

        public void ErrorLog(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }
    }
}
