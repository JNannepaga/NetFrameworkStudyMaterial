﻿using System;
using System.Collections.Generic;
using Unity.Interception;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.Interceptors.InstanceInterceptors.TransparentProxyInterception;

namespace AOPFramework.PolicyInjectionDemo.UsingStandaloneContainer
{
    public class StandaloneAOPFactory
    {
        private static Dictionary<string, object> container = new Dictionary<string, object>();
        //private static 
        public static TInterface RegisterAndResolve<TInterface, TConcrete>(bool enablePipeline = true)
        {
            string proxyKey = typeof(TInterface).FullName +":"+ typeof(TConcrete).FullName;
            if (!container.ContainsKey(proxyKey))
            {
                IEnumerable<IInterceptionBehavior> injectionMembers = enablePipeline ?
                new IInterceptionBehavior[]{
                   
                } : new IInterceptionBehavior[] { };

                object proxy = (TInterface)Intercept.ThroughProxy(
                    typeof(TInterface),
                    Activator.CreateInstance(typeof(TConcrete)),
                    new InterfaceInterceptor(),
                    injectionMembers
                );

                container.Add(proxyKey, proxy);
            }

            return (TInterface)container[proxyKey];
        }

    }
}
