using System.Security.Principal;
using System.Threading;
using Unity;
using Unity.Injection;
using Unity.Interception;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection;
using Unity.Interception.PolicyInjection.MatchingRules;
using Unity.Lifetime;

namespace AOPFramework.PolicyInjectionDemo.UsingUnityContainer
{
    class Client1
    {
        public static void Encounter()
        {
            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity("Administrator"),
                new[] { "ADMIN" });


            UnityFactory.RegisterServices<ICar, BMW>(ContainerDisposer.Transient);
            DriverHandler driver = UnityFactory.ResolveServices<DriverHandler>();
            driver.Invoke();
        }
    }
}
