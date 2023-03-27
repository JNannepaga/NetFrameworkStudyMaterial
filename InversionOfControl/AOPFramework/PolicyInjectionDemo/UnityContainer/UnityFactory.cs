using System;
using System.Collections.Generic;
using Unity;
using Unity.Injection;
using Unity.Interception;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.Interceptors.InstanceInterceptors.TransparentProxyInterception;
using Unity.Interception.Interceptors.TypeInterceptors.VirtualMethodInterception;
using Unity.Interception.PolicyInjection;
using Unity.Interception.PolicyInjection.MatchingRules;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Lifetime;
using Unity.Storage;

namespace AOPFramework.PolicyInjectionDemo.UsingUnityContainer
{
    public enum ContainerDisposer
    {
        Transient,
        Singleton,
        ContainerControlled
    }

    public class UnityFactory
    {
        #region Declarations
        private static readonly UnityContainer _servicesContainer;
        #endregion

        static UnityFactory()
        {
            Console.WriteLine("Initialized Unity Container");
            _servicesContainer = _servicesContainer ?? new UnityContainer();
        }

        public static void RegisterServices<TInterface, TConcrete>(ContainerDisposer containerDisposer, PolicyType policyType=PolicyType.NONE)
        {
            //Register & Intercept
            _servicesContainer.AddNewExtension<Interception>();
            RegisterPolicy<TInterface, TConcrete>(policyType);

            _servicesContainer.RegisterType(
            typeof(TInterface),
            typeof(TConcrete),
            GetTypeLifetimeManager(containerDisposer),
            new InjectionMember[]{
                new Interceptor(new InterfaceInterceptor()),
                new InterceptionBehavior<PolicyInjectionBehavior>(),
                //new InterceptionBehavior<LoggerInterceptionBehaviour>()
            });
        }


        public static TConcrete ResolveServices<TConcrete>()
        {
            return _servicesContainer.Resolve<TConcrete>();
        }

        public static ITypeLifetimeManager GetTypeLifetimeManager(ContainerDisposer containerDisposer)
        {
            ITypeLifetimeManager lifetimeManager = null;
            switch (containerDisposer)
            {
                case ContainerDisposer.Transient:
                    lifetimeManager = new TransientLifetimeManager();
                    break;

                case ContainerDisposer.Singleton:
                    lifetimeManager = new SingletonLifetimeManager();
                    break;

                case ContainerDisposer.ContainerControlled:
                    lifetimeManager = new ContainerControlledLifetimeManager();
                    break;

                default:
                    break;
            }
            return lifetimeManager;
        }

        public static void RegisterPolicy<TInterface, TConcrete>(PolicyType customPolicy)
        {
            switch (customPolicy)
            {
                case PolicyType.NONE:
                    break;
                case PolicyType.ServicePolicyGreeting:
                    InjectionPolicyConfig.ServicePolicyGreeting(_servicesContainer, typeof(TConcrete).Name);
                    break;
                default:
                    break;
            }
        }

    }
}
