using System.Security.Principal;
using System.Threading;

namespace AOPFramework.Type2_InterfaceInterception.UsingUnityContainer
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
