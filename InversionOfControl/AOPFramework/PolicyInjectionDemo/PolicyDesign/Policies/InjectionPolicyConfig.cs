using System;
using System.Collections.Generic;
using Unity;
using Unity.Injection;
using Unity.Interception;
using Unity.Interception.PolicyInjection.MatchingRules;
using Unity.Lifetime;

namespace AOPFramework.PolicyInjectionDemo
{
    public enum PolicyType : int
    {
        NONE,
        ServicePolicyGreeting
    }

    public enum ServicePolicyType : int
    {
        NONE,
        ServicePolicyGreeting
    }


    public delegate void ServicePolicy(UnityContainer container, params object[] args);

    public static class InjectionPolicyConfig
    {
        public static void ServicePolicyGreeting(UnityContainer container, params object[] args)
        {
                   container.Configure<Interception>()
                            .AddPolicy("ServicePolicy_Greeting")
                            .AddMatchingRule<GreetingMatchingRule>()
                            .AddCallHandler<GreetingInterceptorHandler>(
                                new ContainerControlledLifetimeManager(),
                                new InjectionConstructor(),
                                new InjectionProperty("Order", 1));
        }
    }
    
}
