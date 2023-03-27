using System;
using System.Threading;
using System.Collections.Generic;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace AOPFramework.Type2_InterfaceInterception
{
    public class AuthInterceptionBehaviour : IInterceptionBehavior
    {
        public bool WillExecute => true;
        
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

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            if (Thread.CurrentPrincipal.IsInRole("ADMIN"))
            {
                SuccessLog("You are Authencated");
                IMethodReturn result = getNext().Invoke(input, getNext);
                return result;
            }
            else
            {
                ErrorLog("You are not Authenticated");
                throw new UnauthorizedAccessException("You are not Authenticated");
            }
            
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes; 
        }
    }
}
