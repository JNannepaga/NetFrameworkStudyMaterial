using System;
using Unity;
using Unity.Injection;
using Unity.Interception;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.Interceptors.InstanceInterceptors.TransparentProxyInterception;
using Unity.Interception.Interceptors.TypeInterceptors.VirtualMethodInterception;
using Unity.Lifetime;

namespace AOPFramework.Type2_InterfaceInterception.UsingUnityContainer
{
    public enum ContainerDisposer
    {
        Transient,
        Singleton
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

        public static void RegisterServices<TInterface, TConcrete>(ContainerDisposer containerDisposer, bool enablePipeline = true)
        {
            InjectionMember[] injectionMembers = enablePipeline ?
            new InjectionMember[]{
                new Interceptor(new InterfaceInterceptor()),
                new InterceptionBehavior<AuthInterceptionBehaviour>(),
                new InterceptionBehavior<LoggerInterceptionBehaviour>()
            } : new InjectionMember[] { };
            
            //Register & Intercept
            _servicesContainer.AddNewExtension<Interception>();
            _servicesContainer.RegisterType(
            typeof(TInterface),
            typeof(TConcrete),
            GetTypeLifetimeManager(containerDisposer),
            injectionMembers
            );
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

                default:
                    break;
            }
            return lifetimeManager;
        }
    }
}
