using System;
using System.Collections.Generic;

namespace AOPFramework.PolicyInjectionDemo
{
    public class PolicyParams
    {
        public enum PolicyKey { None, Type, Greetings }

        public PolicyKey PolicyId { get; set; }
        public List<Object> PolicyArgs { get; set; }
    }
}
