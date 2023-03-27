using System;
using System.Reflection;
using Unity.Interception.PolicyInjection.MatchingRules;

namespace AOPFramework.PolicyInjectionDemo
{
    class GreetingMatchingRule : IMatchingRule
    {
        public bool Matches(MethodBase member)
        {
            Console.WriteLine(String.Format("Invoking method {0} at {1} ==> {2}", member.Name, DateTime.Now.ToLongTimeString(), member.ToString()));
            return true;
        }
    }
}
