using System.Security.Principal;
using System.Threading;

namespace AOPFramework.Type1_TransparentProxy.UsingUnityContainer
{
    class Client1
    {
        public static void Encounter()
        {
            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity("Administrator"),
                new[] { "ADMIN" });

            
            UnityFactory.RegisterServices<BMW, BMW>(ContainerDisposer.Transient);
            //UnityFactory.RegisterServices<IAuditService, AuditService>(ContainerDisposer.Singleton, false);
            DriverHandler driver = UnityFactory.ResolveServices<DriverHandler>();
            driver.Invoke();
        }
    }
}
