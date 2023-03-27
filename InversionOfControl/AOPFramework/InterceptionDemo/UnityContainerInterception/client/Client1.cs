using AOPFramework.InterceptionDemo;
using System.Security.Principal;
using System.Threading;

namespace AOPFramework.UnityContainerInterception
{
    class Client1
    {
        public static void Encounter()
        {
            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity("Administrator"),
                new[] { "ADMIN" });

            UnityFactory.RegisterServices<ICar, BMW>(ContainerDisposer.Transient);
            UnityFactory.RegisterServices<IAuditService, AuditService>(ContainerDisposer.Singleton, false);
            DriverHandler driver = UnityFactory.ResolveServices<DriverHandler>();
            driver.Invoke();
        }
    }
}
