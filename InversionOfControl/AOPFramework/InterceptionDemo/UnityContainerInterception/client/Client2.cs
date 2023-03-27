using AOPFramework.InterceptionDemo;
using System.Security.Principal;
using System.Threading;

namespace AOPFramework.UnityContainerInterception
{
    class Client2
    {
        public static void Encounter()
        {
            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity("Administrator"),
                new[] { "ADMIN" });

            UnityFactory.RegisterServices<ICar, Suziki>(ContainerDisposer.Transient);
            DriverHandler driver = UnityFactory.ResolveServices<DriverHandler>();
            driver.Invoke();
        }
    }
}
